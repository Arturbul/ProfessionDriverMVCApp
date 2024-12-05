using AutoMapper;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class WorkLogProfile : Profile
    {
        public WorkLogProfile()
        {
            CreateMap<CreateWorkLogEntryRequest, DriverWorkLogEntry>();
        }
    }
}
