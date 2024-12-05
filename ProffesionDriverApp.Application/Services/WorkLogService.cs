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
                    VehicleBrand = dw.TransportUnit.Brand
                })
                .ToListAsync();

            return logs;
        }

        public async Task<string> MakeWorkLogEntry(bool started, CreateWorkLogEntryRequest request)
        {
            var user = await _userContextService.GetAppUser();

            IQueryable<DriverWorkLog> query;
            if (!string.IsNullOrEmpty(request.DriverUserName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                user = await _userManager.FindByNameAsync(request.DriverUserName);
                if (user == null || user.DriverId == null || user.CompanyId == null)
                {
                    throw new InvalidOperationException("User does not have a Driver Profile or not attached to a Company.");
                }
                query = _unitOfWork.Repository<DriverWorkLog>().Queryable(filterCompany: false).Where(a => a.DriverId == user.DriverId);
            }
            else
            {
                if (user == null || user.DriverId == null || user.CompanyId == null)
                {
                    throw new InvalidOperationException("User does not have a Driver Profile or not attached to a Company.");
                }
                query = _unitOfWork.Repository<DriverWorkLog>().Queryable().Where(a => a.DriverId == user.DriverId);
            }

            var latestWorkLog = await query
                .Include(a => a.StartEntry)
                .Include(a => a.EndEntry)
                .OrderByDescending(dw => dw.StartEntry.LogTime)
                .FirstOrDefaultAsync();

            if (started)
            {
                if (latestWorkLog == null || (latestWorkLog.EndEntry != null && latestWorkLog.EndEntry.LogTime > DateTime.MinValue))
                {
                    throw new InvalidOperationException("Could not find latest work log or is already ended.");
                }
                var endEntry = _mapper.Map<DriverWorkLogEntry>(request);
                endEntry.DriverId = user.DriverId.Value;
                _unitOfWork.Repository<DriverWorkLogEntry>().Add(endEntry);

                latestWorkLog.EndEntry = endEntry;
                _unitOfWork.Repository<DriverWorkLog>().FillEntityBase(latestWorkLog);
                await _unitOfWork.SaveToDatabaseAsync();

                return latestWorkLog.DriverWorkLogId.ToString();
            }

            if (latestWorkLog != null && !(latestWorkLog.EndEntry != null && latestWorkLog.EndEntry.LogTime > DateTime.MinValue))
            {
                throw new InvalidOperationException("Could not make a new work log when previous is not ended.");
            }

            // entry
            var startEntry = _mapper.Map<DriverWorkLogEntry>(request);
            startEntry.DriverId = user.DriverId.Value;
            _unitOfWork.Repository<DriverWorkLogEntry>().Add(startEntry);

            //transport unit
            var newUnit = _mapper.Map<TransportUnit>(request);
            newUnit.CompanyId = user.CompanyId.Value;
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
    }
}
