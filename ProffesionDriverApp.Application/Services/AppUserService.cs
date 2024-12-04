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
    public class AppUserService : ServiceBase, IAppUserService
    {
        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService)
            : base(unitOfWork, mapper, userManager, userContextService)
        {
        }

        public async Task<IList<AppUserUnassignedDTO?>?> Unassigned()
        {
            var now = DateOnly.FromDateTime(DateTime.UtcNow);

            var entities = await _unitOfWork.Repository<AppUser>()
                .Queryable()
                .Include(a => a.Employee)
                .Where(a => a.CompanyId == null &&
                            (a.Employee == null ||
                             (a.Employee.TerminationDate == null || a.Employee.TerminationDate <= now) &&
                             a.Employee.HireDate <= now &&
                             (a.Employee.CompanyId != 0 || !a.Employee.Company.IsDeleted)))
                .ToListAsync();

            if (!entities.Any())
            {
                return null;
            }

            var mapped = _mapper.Map<IList<AppUserUnassignedDTO?>>(entities);
            if (!mapped.Any())
            {
                throw new InvalidOperationException("Error mapping");
            }
            return mapped;
        }

        public async Task<AppUserDTO?> GetAppUser(string? identifier)
        {
            var user = await _userContextService.GetAppUser();
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                user = await _unitOfWork.Repository<AppUser>()
                    .Queryable()
                    .FirstOrDefaultAsync(a =>
                        a.NormalizedEmail == _userManager.NormalizeEmail(identifier)
                        || a.NormalizedUserName == _userManager.NormalizeName(identifier));
            }

            return _mapper.Map<AppUserDTO?>(user);
        }
    }
}
