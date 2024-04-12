using Business.Generic.Interface;
using Domain.Models;
using Domain.ViewModels;
namespace Business.Interface
{
    public interface IEntityManager : ITManager<Entity, EntityViewModel>
    {
    }
}
