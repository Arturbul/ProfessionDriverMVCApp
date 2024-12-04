using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Update;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Application.Mappers
{
    public class CompanyServiceProfile : Profile
    {
        public CompanyServiceProfile()
        {
            // Mapping for Address -> AddressDTO
            CreateMap<Address, AddressDTO>();

            // Mapping for Company -> CompanyBasicDTO
            CreateMap<Company, CompanyBasicDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address != null ? src.Address.City : ""))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : null))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address != null ? src.Address.PostalCode : null))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address != null ? src.Address.Country : null));

            CreateMap<UpdateCompanyRequest, Company>();
        }
    }
}
