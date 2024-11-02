using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService)
            : base(unitOfWork, mapper, userManager, userContextService)
        {
        }

        /// <summary>
        /// Assigns a user to an employee record within a specified company.
        /// </summary>
        /// <param name="request">Input data for linking a user account to an employee record</param>
        public async Task AssignUserToCompanyEmployee(LinkUserToEmployeeRequest request)
        {
            var userParent = await GetParentUser();
            var companyId = userParent!.CompanyId!.Value;

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new InvalidOperationException("Could not find user.");

            // Check if the user is already linked to an Employee
            if (user.EmployeeId != null)
                throw new InvalidOperationException("User is already linked to an Employee.");

            // Check if the Employee exists
            var employee = await _unitOfWork.Repository<Employee>()
                .Queryable()
                .FirstOrDefaultAsync(a => a.EmployeeId == user.EmployeeId);
            if (employee == null)
            {
                // Optionally create a new Employee record if none exists
                employee = new Employee
                {
                    Name = request.EmployeeName,
                    HireDate = request.HireDate,
                    AppUserId = user.Id,
                    AppUser = user,
                    Address = request.Address,
                };
                CreateFillEntity(employee);
            }

            var company = _unitOfWork.Repository<Company>()
                .Queryable()
                .Include(a => a.Employees)
                    .ThenInclude(a => a.AppUser)
                .AsTracking()
                .FirstOrDefault();
            if (company == null)
                throw new InvalidOperationException("Company is not avialable");

            company.AddEmployee(employee);
            UpdateFillEntity(employee);

            await _unitOfWork.SaveToDatabaseAsync();
        }

        public async Task Create(CreateCompanyRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.ManagerLogin);
            if (user == null)
                throw new InvalidOperationException("Could not find user.");
            if (user.CompanyId.HasValue)
                throw new InvalidOperationException("User already assign to company.");

            var profile = new Company
            {
                Name = request.Name,
                Address = request.Address,
            };
            CreateFillEntity(profile);

            var employeeProfile = await _unitOfWork
                .Repository<Employee>()
                .Queryable(false, Domain.ValueObjects.EntityStatusFilter.All)
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(a => a.EmployeeId == user.EmployeeId);

            if (employeeProfile != null)
            {
                if (employeeProfile.IsActive || employeeProfile.IsEmployed || employeeProfile.IsDeleted != true)
                {
                    throw new InvalidOperationException("User already assign to other company.");
                }
                UpdateFillEntity(employeeProfile);
            }
            else
            {
                employeeProfile = new Employee
                {
                    AppUserId = user.Id,
                    AppUser = user,
                };
                CreateFillEntity(employeeProfile);
            }

            profile.AddEmployee(employeeProfile);
            _unitOfWork.Repository<Company>().Add(profile);
            await _unitOfWork.SaveToDatabaseAsync();
        }
    }
}
