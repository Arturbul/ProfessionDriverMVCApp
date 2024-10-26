using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Domain.Profiles
{
    public class IndividualProfile : Profile
    {
        public IndividualProfile()
        {
            CreateMap<Individual, IndividualDTO>();
            CreateMap<IndividualDTO, Individual>();
        }
    }
}
