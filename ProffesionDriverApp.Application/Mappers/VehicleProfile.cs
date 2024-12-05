using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleRequest, Vehicle>().ReverseMap();
            CreateMap<CreateVehicleRequest, LargeGoodsVehicle>().ReverseMap();

            CreateMap<Vehicle, VehicleDTO>();

            CreateMap<LargeGoodsVehicle, VehicleDTO>()
                .IncludeBase<Vehicle, VehicleDTO>() // Inheriting mapping from Vehicle
                .ForMember(dest => dest.IsLGV, opt => opt.MapFrom(src => true)) // Always true
                .ForMember(dest => dest.TachoExpiryDate, opt => opt.MapFrom(src => src.TachoExpiryDate));
        }
    }
}
