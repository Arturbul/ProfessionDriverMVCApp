using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;
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
                .Include(dw => dw.LargeGoodsVehicle)
                .ThenInclude(lgv => lgv.Vehicle)
                .Include(dw => dw.LargeGoodsVehicle.Trailer)
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
                    VehicleNumber = dw.LargeGoodsVehicle.Vehicle.RegistrationNumber,
                    TrailerNumber = dw.LargeGoodsVehicle.Trailer != null ? dw.LargeGoodsVehicle.Trailer.RegistrationNumber : "",
                    VehicleBrand = dw.LargeGoodsVehicle.Vehicle.Brand
                })
                .ToListAsync();

            return logs;
        }
    }
}
