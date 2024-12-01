using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class CompanyServiceProfile : Profile
    {
        public CompanyServiceProfile()
        {
            CreateMap<Company, CompanyBasicDTO>()
                .ForMember(a => a.Address, opt => opt.MapFrom(dest => dest.Address));
        }
    }
}
