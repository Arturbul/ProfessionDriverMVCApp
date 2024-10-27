using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Domain.Profiles
{
    public class IndividualProfile : Profile
    {
        public IndividualProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
