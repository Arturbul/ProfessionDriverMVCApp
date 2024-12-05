using AutoMapper;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class TransportUnitProfile : Profile
    {
        public TransportUnitProfile()
        {
            CreateMap<CreateWorkLogEntryRequest, TransportUnit>();
        }
    }
}
