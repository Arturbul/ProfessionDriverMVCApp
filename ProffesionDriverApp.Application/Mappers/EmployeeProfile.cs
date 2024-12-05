using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                  .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser))
                  .ForMember(dest => dest.IsEmployed, opt => opt.MapFrom(src => src.IsEmployed))
                  .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                  .ForMember(dest => dest.IsDriver, opt => opt.MapFrom(src => src.DriverId != null))
                  .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate))
                  .ForMember(dest => dest.TerminationDate, opt => opt.MapFrom(src => src.TerminationDate))
                  .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
