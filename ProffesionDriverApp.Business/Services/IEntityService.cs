using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.Business.Searchers;
using ProfessionDriverApp.Domain.Models;
namespace ProfessionDriverApp.Business.Services
{
    public interface IEntityService : ITService<Entity, EntitySearcher, int>
    {
    }
}
