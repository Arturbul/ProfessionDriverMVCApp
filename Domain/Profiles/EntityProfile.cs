using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace Domain.Profiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, EntityViewModel>();
            CreateMap<EntityViewModel, Entity>();
        }
    }
}
