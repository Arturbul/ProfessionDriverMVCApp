using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IUserContextService _userContextService;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IMapper _mapper;

        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _userContextService = userContextService;
        }

        public void CreateFillEntity<T>(T entity)
           where T : EntityBase
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = false;
            entity.Created = DateTime.UtcNow;
            entity.Creator = userName;
        }

        public void UpdateFillEntity<T>(T entity)
            where T : EntityBase
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = false;
            entity.Modified = DateTime.UtcNow;
            entity.Modifier = userName;
        }
        public void Delete<T>(T entity)
            where T : EntityBase
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = true;
            entity.Modified = DateTime.UtcNow;
            entity.Modifier = userName;
        }

        #region GetParentUser
        protected async Task<AppUser> GetParentUser()
        {
            var userParent = await _userManager.FindByNameAsync(_userContextService.GetUserName() ?? "");
            if (userParent == null
                || !userParent.CompanyId.HasValue
                || !await _unitOfWork.Repository<Company>().Queryable().AnyAsync())
                throw new UnauthorizedAccessException("Unauthorized");
            return userParent;
        }
        #endregion
    }
}
