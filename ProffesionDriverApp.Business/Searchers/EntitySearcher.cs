using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.Domain.Models;
using System.Linq.Expressions;

namespace ProfessionDriverApp.Business.Searchers
{
    public class EntitySearcher : ITSearcher<Entity>
    {
        public Expression<Func<Entity, bool>> Search()
        {
            throw new NotImplementedException();
        }
    }
}
