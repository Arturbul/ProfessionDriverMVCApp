using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverRepository
    {
        Task<ICollection<Driver>> Get();
        Task<Driver?> Get(int id);
        Task<int> Create(Driver driver);
        Task<int> Update(Driver driver);
        Task<int> Delete(int driverId);
    }
}
