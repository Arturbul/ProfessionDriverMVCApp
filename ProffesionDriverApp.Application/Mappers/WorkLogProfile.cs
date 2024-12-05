using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class WorkLogProfile : Profile
    {
        public WorkLogProfile()
        {
            CreateMap<CreateWorkLogEntryRequest, DriverWorkLogEntry>();

            // Mapowanie z DriverWorkLog na DriverWorkLogDTO
            CreateMap<DriverWorkLog, DriverWorkLogDTO>()
                .ForMember(dest => dest.DriverWorkLogId, opt => opt.MapFrom(src => src.DriverWorkLogId)) // Przykład mapowania GUID
                                                                                                         //.ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.Driver.Employee.AppUser))
                .ForMember(dest => dest.TransportUnit, opt => opt.MapFrom(src => src.TransportUnit))
                .ForMember(dest => dest.StartEntry, opt => opt.MapFrom(src => src.StartEntry))
                .ForMember(dest => dest.EndEntry, opt => opt.MapFrom(src => src.EndEntry));

            // Mapowanie z DriverWorkLogEntry na DriverWorkLogEntryDTO
            CreateMap<DriverWorkLogEntry, DriverWorkLogEntryDTO>()
                .ForMember(dest => dest.LogTime, opt => opt.MapFrom(src => src.LogTime))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Mileage, opt => opt.MapFrom(src => src.Mileage));
        }
    }
}
