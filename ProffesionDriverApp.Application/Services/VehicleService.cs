﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    public class VehicleService : ServiceBase, IVehicleService
    {
        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IUserContextService userContextService) : base(unitOfWork, mapper, userManager, userContextService) { }

        public async Task<int> CreateVehicle(CreateVehicleRequest request)
        {
            var user = await _userContextService.GetAppUser();
            int? companyId = null;
            if (await _unitOfWork.Repository<Vehicle>().Queryable(filterCompany: false).AnyAsync(a => a.RegistrationNumber.ToLower() == request.RegistrationNumber.ToLower()))
            {
                throw new InvalidOperationException($"Vehicle '{request.RegistrationNumber.ToUpper()}' already exists.");
            }

            if (!string.IsNullOrEmpty(request.CompanyName) && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                companyId = await _unitOfWork.Repository<Company>().Queryable(filterCompany: false).Where(a => a.Name == request.CompanyName).Select(a => a.CompanyId).FirstOrDefaultAsync();
            }
            else
            {
                companyId = user.CompanyId;
            }

            if (!companyId.HasValue || companyId.Value == 0)
            {
                throw new InvalidOperationException($"Company '{request.CompanyName}' does not exists or unauthorized.");
            }

            if (request.IsLGV)
            {
                var newVehicle = _mapper.Map<LargeGoodsVehicle>(request);
                newVehicle.CompanyId = companyId.Value;

                _unitOfWork.Repository<LargeGoodsVehicle>().Add(newVehicle);
                await _unitOfWork.SaveToDatabaseAsync();

                return newVehicle.VehicleId;
            }
            else
            {
                var newVehicle = _mapper.Map<Vehicle>(request);
                newVehicle.CompanyId = companyId.Value;

                _unitOfWork.Repository<Vehicle>().Add(newVehicle);
                await _unitOfWork.SaveToDatabaseAsync();

                return newVehicle.VehicleId;
            }
        }
    }
}
