using System.Linq.Expressions;

namespace ProfessionDriverApp.Business.Common
{
    public interface ITSearcher<T>
        where T : class
    {
        Expression<Func<T, bool>> Search();
    }
}
