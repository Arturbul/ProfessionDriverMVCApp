using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Domain.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(src => src.Entity, opt => opt.MapFrom(src => src.Entity))
                .ForMember(src => src.VehicleInspection, opt => opt.MapFrom(src => src.VehicleInspection))
                .ForMember(src => src.VehicleInsurance, opt => opt.MapFrom(src => src.VehicleInsurance));

            CreateMap<VehicleViewModel, Vehicle>()
                .ForMember(src => src.Entity, opt => opt.MapFrom(src => src.Entity))
                .ForMember(src => src.VehicleInspection, opt => opt.MapFrom(src => src.VehicleInspection))
                .ForMember(src => src.VehicleInsurance, opt => opt.MapFrom(src => src.VehicleInsurance));
        }
    }
}
