using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class LargeGoodsVehicleProfile : Profile
    {
        public LargeGoodsVehicleProfile()
        {
            CreateMap<LargeGoodsVehicle, LargeGoodsVehicleViewModel>()
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
                .ForMember(dest => dest.Trailer, opt => opt.MapFrom(src => src.Vehicle));

            CreateMap<LargeGoodsVehicleViewModel, LargeGoodsVehicle>()
               .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
               .ForMember(dest => dest.Trailer, opt => opt.MapFrom(src => src.Vehicle));
        }
    }
}
