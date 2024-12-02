using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Application.Requests.Update;
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
            var user = await _userManager.FindByNameAsync(request.ManagerUserName);
            if (user == null)
                throw new InvalidOperationException("Could not find user.");
            if (user.CompanyId.HasValue)
                throw new InvalidOperationException("User already assign to company.");

            if (await _unitOfWork.Repository<Company>().Queryable(filterCompany: false)
                    .AnyAsync(a => a.Name.ToLower().Trim() == request.Name.ToLower().Trim()))
            {
                throw new InvalidOperationException("Company with that name already exists.");
            }

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

        public async Task<IList<CompanyBasicDTO?>?> CompaniesWithDetails()
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var companies = _unitOfWork.Repository<Company>()
                    .Queryable(filterCompany: false);

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return _mapper.Map<IList<CompanyBasicDTO?>>(companies);
            }

            //return list of companies where user is an employee
            companies
                .Include(a => a.Employees)
                .Where(a => a.Employees
                    .Any(b => b.AppUserId == user.Id));

            return _mapper.Map<IList<CompanyBasicDTO?>>(companies);
        }

        public async Task<IList<CompanyBasicDTO?>?> CompaniesBasics()
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var companies = _unitOfWork.Repository<Company>()
                    .Queryable(filterCompany: false);

            return _mapper.Map<IList<CompanyBasicDTO?>>(companies);
        }

        public async Task<CompanyBasicDTO> CompanyBasic(string? name)
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            Company? company = null;
            if (!string.IsNullOrEmpty(name) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                company = await _unitOfWork.Repository<Company>()
                    .Queryable(filterCompany: false)
                    .SingleOrDefaultAsync(a => a.Name == name);
            }
            else
            {
                company = await _unitOfWork.Repository<Company>()
                   .Queryable()
                   .FirstOrDefaultAsync();
            }

            if (company == null)
            {
                throw new UnauthorizedAccessException();
            }
            return _mapper.Map<CompanyBasicDTO>(company);
        }

        public async Task OffCompanyProfile(int id)
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !(await _userManager.IsInRoleAsync(user, "Admin")))
            {
                throw new UnauthorizedAccessException();
            }

            var query = _unitOfWork.Repository<Company>().Queryable(filterCompany: false);
            if (!(await query.AnyAsync(a => a.CompanyId == id)))
            {
                throw new InvalidOperationException("Invalid company id.");
            }

            await _unitOfWork.Repository<Company>().Delete(id);
            var result = await _unitOfWork.SaveToDatabaseAsync();
            if (result == 0)
            {
                throw new DbUpdateException("Cannot detete entity from database.");
            }
        }

        public async Task OffCompanyProfileWithEmployees(int id)
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !(await _userManager.IsInRoleAsync(user, "Admin")))
            {
                throw new UnauthorizedAccessException();
            }

            var query = _unitOfWork.Repository<Company>().Queryable(filterCompany: false);
            if (!(await query.AnyAsync(a => a.CompanyId == id)))
            {
                throw new InvalidOperationException("Invalid company id.");
            }

            var profile = await query.Include(a => a.Employees)
                .ThenInclude(a => a.AppUser)
                .AsTracking()
                .FirstOrDefaultAsync(a => a.CompanyId == id);
            if (profile == null)
            {
                throw new NullReferenceException("Cannot get company profile.");
            }

            foreach (var employee in profile.Employees)
            {
                profile.RemoveEmployee(employee);
            }

            await _unitOfWork.Repository<Company>().Delete(id);
            var result = await _unitOfWork.SaveToDatabaseAsync();
            if (result == 0)
            {
                throw new DbUpdateException("Cannot detete entity from database.");
            }
        }

        public async Task UpdateCompanyBasics(string? name, UpdateCompanyRequest request)
        {
            var user = await _userContextService.GetAppUser();

            Company? company = null;
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                company = await _unitOfWork.Repository<Company>().Queryable(filterCompany: false).FirstOrDefaultAsync(a => a.Name == name);
            }
            else
            {
                company = await _unitOfWork.Repository<Company>().Queryable().FirstOrDefaultAsync();
            }

            if (company == null)
            {
                throw new NullReferenceException("Company not found.");
            }

            _mapper.Map(request, company);

            _unitOfWork.Repository<Company>().Update(company);
            await _unitOfWork.SaveToDatabaseAsync();
        }
    }
}
