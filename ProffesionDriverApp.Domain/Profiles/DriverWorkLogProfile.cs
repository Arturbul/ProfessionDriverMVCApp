using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class DriverWorkLogProfile : Profile
    {
        public DriverWorkLogProfile()
        {
            CreateMap<DriverWorkLog, DriverWorkLogViewModel>()
                .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => src.Driver))
                .ForMember(dest => dest.LargeGoodsVehicle, opt => opt.MapFrom(src => src.LargeGoodsVehicle))
                .ForMember(dest => dest.StartEntry, opt => opt.MapFrom(src => src.StartEntry))
                .ForMember(dest => dest.EndEntry, opt => opt.MapFrom(src => src.EndEntry));

            CreateMap<DriverWorkLogViewModel, DriverWorkLog>()
                .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => src.Driver))
                .ForMember(dest => dest.LargeGoodsVehicle, opt => opt.MapFrom(src => src.LargeGoodsVehicle))
                .ForMember(dest => dest.StartEntry, opt => opt.MapFrom(src => src.StartEntry))
                .ForMember(dest => dest.EndEntry, opt => opt.MapFrom(src => src.EndEntry));
        }
    }
}
