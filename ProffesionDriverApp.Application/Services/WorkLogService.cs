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

        public async Task<float> TotalDistance(string? name)
        {
            var user = await _userContextService.GetAppUser();

            var query = _unitOfWork.Repository<Company>().Queryable(filterCompany: false);
            if (!string.IsNullOrEmpty(name) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                query.Where(a => a.Name == name);
            }
            else
            {
                query.Where(a => a.CompanyId == _userContextService.GetUserCompany());
            }

            var totalMileage = await query
                .SelectMany(company => company.Drivers)
                .SelectMany(driver => driver.DriverWorkLogs
                    .Where(workLog => !workLog.IsDeleted && workLog.EndEntry != null))
                .SumAsync(workLog => workLog.EndEntry!.Mileage.GetValueOrDefault() - workLog.StartEntry.Mileage.GetValueOrDefault());

            return totalMileage;
        }
    }
}
