using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverViewModel>()
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));
            CreateMap<DriverViewModel, Driver>()
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));
        }
    }
}
