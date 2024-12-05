using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class TransportUnitProfile : Profile
    {
        public TransportUnitProfile()
        {
            CreateMap<CreateWorkLogEntryRequest, TransportUnit>();

            // Mapowanie z TransportUnit na TransportUnitDTO
            CreateMap<TransportUnit, TransportUnitDTO>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.RegistrationNumber))
                .ForMember(dest => dest.BrandTrailer, opt => opt.MapFrom(src => src.TrailerBrand))
                .ForMember(dest => dest.RegistrationNumberTrailer, opt => opt.MapFrom(src => src.RegistrationNumberTrailer));
        }
    }
}
