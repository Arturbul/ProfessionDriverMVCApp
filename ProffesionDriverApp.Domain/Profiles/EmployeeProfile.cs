using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(src => src.Entity));
            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(src => src.Entity));
        }
    }
}
