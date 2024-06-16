using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class VehicleInsuranceProfile : Profile
    {
        public VehicleInsuranceProfile()
        {
            CreateMap<VehicleInsurance, VehicleInsuranceViewModel>()
                .ForMember(dest => dest.OC_Policy, opt => opt.MapFrom(src => src.OC_Policy))
                .ForMember(dest => dest.AC_Policy, opt => opt.MapFrom(src => src.AC_Policy));

            CreateMap<VehicleInsuranceViewModel, VehicleInsurance>()
                .ForMember(dest => dest.OC_Policy, opt => opt.MapFrom(src => src.OC_Policy))
                .ForMember(dest => dest.AC_Policy, opt => opt.MapFrom(src => src.AC_Policy));
        }
    }
}
