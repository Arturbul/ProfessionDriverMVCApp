using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;
using System.Globalization;

namespace ProfessionDriverApp.Application.Services
{
    public class WorkLogService : ServiceBase, IWorkLogService
    {
        public WorkLogService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService)
            : base(unitOfWork, mapper, userManager, userContextService)
        {
        }

        public async Task<float> TotalDistanceCompany(string? companyName, DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var user = await _userContextService.GetAppUser();

            var query = _unitOfWork.Repository<Company>().Queryable(filterCompany: false);
            if (!string.IsNullOrEmpty(companyName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query.Where(a => a.Name == companyName);
            }
            else
            {
                query.Where(a => a.CompanyId == _userContextService.GetUserCompany());
            }

            startDate = startDate ?? DateTime.MinValue;
            endDate = endDate ?? DateTime.MaxValue;

            var totalMileage = await query
                .SelectMany(company => company.Drivers)
                .SelectMany(driver => driver.DriverWorkLogs
                    .Where(workLog => !workLog.IsDeleted
                    && workLog.EndEntry != null
                    && workLog.StartEntry.LogTime >= startDate
                    && workLog.EndEntry.LogTime <= endDate))
                .SumAsync(workLog => workLog.EndEntry!.Mileage.GetValueOrDefault() - workLog.StartEntry.Mileage.GetValueOrDefault());

            return totalMileage;
        }

        public async Task<float> TotalDistanceDriver(string? driverUserName, DateTime? startDate = null,
           DateTime? endDate = null)
        {
            var user = await _userContextService.GetAppUser();

            var query = _unitOfWork.Repository<Driver>().Queryable(filterCompany: false);
            if (!string.IsNullOrEmpty(driverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query.Where(a => a.Employee!.AppUser!.UserName == driverUserName);
            }
            else
            {
                query.Where(a => a.Employee!.AppUser!.UserName == _userContextService.GetUserName());
            }

            startDate = startDate ?? DateTime.MinValue;
            endDate = endDate ?? DateTime.MaxValue;

            var totalMileage = await query
                .SelectMany(driver => driver.DriverWorkLogs
                    .Where(workLog => !workLog.IsDeleted
                    && workLog.EndEntry != null
                    && workLog.StartEntry.LogTime >= startDate
                    && workLog.EndEntry.LogTime <= endDate))
                .SumAsync(workLog => workLog.EndEntry!.Mileage.GetValueOrDefault() - workLog.StartEntry.Mileage.GetValueOrDefault());

            return totalMileage;
        }

        public async Task<TimeSpan> TotalWorkedHours(string? driverUserName, DateTime? startDate = null, DateTime? endDate = null)
        {
            var user = await _userContextService.GetAppUser();

            // Tworzenie zapytania
            var query = _unitOfWork.Repository<Driver>().Queryable(filterCompany: false);
            if (!string.IsNullOrEmpty(driverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query = query.Where(a => a.Employee!.AppUser!.UserName == driverUserName);
            }
            else
            {
                query = query.Where(a => a.Employee!.AppUser!.UserName == _userContextService.GetUserName());
            }

            startDate = startDate ?? DateTime.MinValue;
            endDate = endDate ?? DateTime.MaxValue;

            var totalWorkedHours = await query
                .SelectMany(driver => driver.DriverWorkLogs
                    .Where(workLog => !workLog.IsDeleted
                        && workLog.EndEntry != null
                        && workLog.StartEntry.LogTime >= startDate
                        && workLog.EndEntry.LogTime <= endDate))
                .SumAsync(workLog => EF.Functions.DateDiffMinute(workLog.StartEntry.LogTime, workLog.EndEntry.LogTime));

            return TimeSpan.FromMinutes(totalWorkedHours);
        }

        public async Task<List<object>> DistanceDriverYear(string? driverUserName)
        {
            var user = await _userContextService.GetAppUser();

            var query = _unitOfWork.Repository<Driver>().Queryable(filterCompany: false);
            if (!string.IsNullOrEmpty(driverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query = query.Where(a => a.Employee!.AppUser!.UserName == driverUserName);
            }
            else
            {
                query = query.Where(a => a.Employee!.AppUser!.UserName == _userContextService.GetUserName());
            }

            var currentYear = DateTime.UtcNow.Year;
            var result = await query
                .SelectMany(driver => driver.DriverWorkLogs
                    .Where(workLog => !workLog.IsDeleted
                        && workLog.EndEntry != null
                        && workLog.StartEntry.LogTime.Year == currentYear))
                .GroupBy(workLog => workLog.StartEntry.LogTime.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    Distance = group.Sum(workLog =>
                        workLog.EndEntry!.Mileage.GetValueOrDefault() - workLog.StartEntry.Mileage.GetValueOrDefault())
                })
                .ToListAsync();

            var monthNames = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames;
            var allMonthsWithDistance = Enumerable.Range(1, 12)
                .Select(month => new
                {
                    month = monthNames[month - 1],
                    distance = result.FirstOrDefault(r => r.Month == month)?.Distance ?? 0
                })
                .ToList();

            return allMonthsWithDistance.Cast<object>().ToList();
        }

        public async Task<List<DriverWorkLogSummaryDTO>> GetRecentDriverWorkLogs(string? driverUserName, int logCount = 5)
        {
            var user = await _userContextService.GetAppUser();

            IQueryable<DriverWorkLog> query = _unitOfWork.Repository<DriverWorkLog>().Queryable(filterCompany: false)
                .Include(dw => dw.TransportUnit)
                .Include(dw => dw.StartEntry)
                .Include(dw => dw.EndEntry);

            if (!string.IsNullOrEmpty(driverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query = query.Where(dw => dw.Driver.Employee!.AppUser!.UserName == driverUserName);
            }
            else
            {
                query = query.Where(dw => dw.Driver.Employee!.AppUser!.UserName == _userContextService.GetUserName());
            }

            var logs = await query
                .OrderByDescending(dw => dw.StartEntry.LogTime)
                .Where(dw => !dw.IsDeleted && dw.EndEntry != null)
                .Take(logCount)
                .Select(dw => new DriverWorkLogSummaryDTO
                {
                    DriverWorkLogId = dw.DriverWorkLogId,
                    StartPlace = dw.StartEntry.Place,
                    EndPlace = dw.EndEntry!.Place,
                    TotalDistance = dw.EndEntry != null && dw.StartEntry.Mileage.HasValue && dw.EndEntry.Mileage.HasValue
                        ? dw.EndEntry.Mileage.Value - dw.StartEntry.Mileage.Value
                        : null,
                    TotalHours = dw.EndEntry != null
                        ? (float)(dw.EndEntry.LogTime - dw.StartEntry.LogTime).TotalHours
                        : null,
                    VehicleNumber = dw.TransportUnit.RegistrationNumber,
                    TrailerNumber = dw.TransportUnit.RegistrationNumberTrailer != null ? dw.TransportUnit.RegistrationNumberTrailer : "",
                    VehicleBrand = dw.TransportUnit.Brand,
                    TrailerBrand = dw.TransportUnit.TrailerBrand != null ? dw.TransportUnit.TrailerBrand : "",
                })
                .ToListAsync();

            return logs;
        }

        // TODO wyodrębnic metode do pobrania latestDriverWorkLog by połączyć z FE
        public async Task<string> MakeWorkLogEntry(bool started, CreateWorkLogEntryRequest request)
        {
            var user = await _userContextService.GetAppUser();

            if (!string.IsNullOrEmpty(request.DriverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                user = await _userManager.FindByNameAsync(request.DriverUserName);
            }

            if (user == null)
            {
                throw new NullReferenceException("Could not find user.");
            }

            var latestWorkLog = (await GetLatestsWorkLogsFromDb(user: user, current: true))?.FirstOrDefault();

            bool isDeclaredEndEntry = latestWorkLog != null && latestWorkLog?.EndEntry != null && latestWorkLog.EndEntry.LogTime > DateTime.MinValue;
            if (started)
            {
                if (latestWorkLog == null || isDeclaredEndEntry)
                {
                    throw new InvalidOperationException("Could not find latest work log or is already ended.");
                }
                // - Fupdate dedicated validator for worklogentries
                if (request.Mileage < latestWorkLog.StartEntry.Mileage)
                {
                    throw new InvalidOperationException($"Current mileage {request.Mileage} is lower then started mileage {latestWorkLog.StartEntry.Mileage}.");
                }

                if (request.LogTime < latestWorkLog.StartEntry.LogTime)
                {
                    throw new InvalidOperationException($"Current log time {request.LogTime} is lower then started log time {latestWorkLog.StartEntry.LogTime}.");
                }

                var endEntry = _mapper.Map<DriverWorkLogEntry>(request);
                endEntry.DriverId = user!.DriverId!.Value;
                _unitOfWork.Repository<DriverWorkLogEntry>().Add(endEntry);

                latestWorkLog.EndEntry = endEntry;
                _unitOfWork.Repository<DriverWorkLog>().FillEntityBase(latestWorkLog);
                await _unitOfWork.SaveToDatabaseAsync();

                return latestWorkLog.DriverWorkLogId.ToString();
            }

            if (latestWorkLog != null && !isDeclaredEndEntry)
            {
                throw new InvalidOperationException("Could not make a new work log when previous is not ended.");
            }

            // entry
            var startEntry = _mapper.Map<DriverWorkLogEntry>(request);
            startEntry.DriverId = user!.DriverId!.Value;
            _unitOfWork.Repository<DriverWorkLogEntry>().Add(startEntry);

            //transport unit
            var newUnit = _mapper.Map<TransportUnit>(request);
            newUnit.CompanyId = user!.CompanyId!.Value;
            _unitOfWork.Repository<TransportUnit>().Add(newUnit);

            // DriverWorkLog
            var newWorkLog = new DriverWorkLog
            {
                TransportUnit = newUnit,
                StartEntry = startEntry,
                DriverId = user.DriverId.Value,
                CompanyId = user.CompanyId.Value,
            };
            _unitOfWork.Repository<DriverWorkLog>().Add(newWorkLog);

            await _unitOfWork.SaveToDatabaseAsync();

            return newWorkLog.DriverWorkLogId.ToString();
        }

        public async Task<IList<DriverWorkLogDTO?>?> GetWorkLogs(string? driverUserName)
        {
            var user = await _userContextService.GetAppUser();

            IQueryable<DriverWorkLog> query = _unitOfWork.Repository<DriverWorkLog>().Queryable(filterCompany: false)
                .Include(a => a.TransportUnit)
                .Include(a => a.StartEntry)
                .Include(a => a.EndEntry);

            if (!string.IsNullOrWhiteSpace(driverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                user = await _userManager.FindByNameAsync(driverUserName);
            }
            if (user == null || !user.DriverId.HasValue)
            {
                throw new InvalidOperationException("User is not driver or unauthorized.");
            }
            query.Where(a => a.CompanyId == user.CompanyId);

            var workLogs = await query.ToListAsync();

            return _mapper.Map<IList<DriverWorkLogDTO?>?>(workLogs);
        }

        public async Task<DriverWorkLogDTO?> GetWorkLog(string? id)
        {
            DriverWorkLog? result = await GetWorkLogFromDb(id);

            return _mapper.Map<DriverWorkLogDTO?>(result);
        }

        private async Task<DriverWorkLog?> GetWorkLogFromDb(string? id)
        {
            var user = await _userContextService.GetAppUser();

            IQueryable<DriverWorkLog> query = _unitOfWork.Repository<DriverWorkLog>().Queryable(filterCompany: false)
                .Include(a => a.TransportUnit)
                .Include(a => a.StartEntry)
                .Include(a => a.EndEntry);

            DriverWorkLog? result = null;
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                result = await query.FirstOrDefaultAsync(a => a.DriverWorkLogId.ToString() == id);
            }
            else
            {
                result = await query.Where(a => a.CompanyId == user.CompanyId)
                    .FirstOrDefaultAsync(a => a.DriverWorkLogId.ToString() == id);
            }

            return result;
        }

        private async Task<IList<DriverWorkLog>?> GetLatestsWorkLogsFromDb(AppUser user, int? count = null, bool? current = null)
        {
            if (user.DriverId == null || user.CompanyId == null)
            {
                throw new InvalidOperationException("User does not have a Driver Profile or not attached to a Company.");
            }

            bool filterDriverByAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            var query = _unitOfWork.Repository<DriverWorkLog>().Queryable(filterCompany: !filterDriverByAdmin)
                .Where(a => a.DriverId == user.DriverId);

            if (current.HasValue && current.Value)
            {
                query = query.Where(a => a.EndEntry == null);
            }

            var latestWorkLog = await query
                .Include(a => a.TransportUnit)
                .Include(a => a.StartEntry)
                .Include(a => a.EndEntry)
                .OrderByDescending(dw => dw.StartEntry.LogTime)
                .Take(count ?? 1)
                .ToListAsync();

            return latestWorkLog;
        }

        //public async Task<string> UpdateDriverWorkLogEntry(string id, CreateWorkLogEntryRequest request)
        //{
        //    var prev = await GetWorkLogFromDb(id);
        //    if (prev == null)
        //    {
        //        throw new InvalidOperationException("WOrklog not found or unauthorized.");
        //    }
        //    _mapper.Map(request, prev);

        //    //TODO
        //}
    }
}
