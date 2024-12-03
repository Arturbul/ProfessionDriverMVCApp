using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

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
    }
}
