using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    internal class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService) : base(unitOfWork, mapper, userManager, userContextService) { }

        public async Task<IList<EmployeeDTO?>?> GetEmployees(string? companyName)
        {
            var user = await _userContextService.GetAppUser();

            IQueryable<Employee>? employees = null;
            if (!string.IsNullOrWhiteSpace(companyName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                employees = _unitOfWork.Repository<Employee>()
                    .Queryable(filterCompany: false)
                    .Where(a => a.Company!.Name == companyName);
            }
            else
            {
                employees = _unitOfWork.Repository<Employee>()
                   .Queryable();
            }
            var result = await employees.Include(a => a.AppUser).ToListAsync();
            return _mapper.Map<IList<EmployeeDTO?>?>(result);
        }
    }
}
