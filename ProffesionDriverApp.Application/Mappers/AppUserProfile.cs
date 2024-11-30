using AutoMapper;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserUnassignedDTO>().ReverseMap();
        }
    }
}
