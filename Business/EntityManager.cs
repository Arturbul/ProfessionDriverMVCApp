using AutoMapper;
using Business.Generic;
using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business
{
    public class EntityManager : TManager<Entity, EntityViewModel, IEntityRepository>, IEntityManager
    {
        public EntityManager(IMapper mapper, IEntityRepository entityRepository) : base(mapper, entityRepository) { }
    }
}
