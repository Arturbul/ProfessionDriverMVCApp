using Domain.Models;

namespace Business.Interface
{
    public interface IDriverManager
    {
        Task<ICollection<Driver>> Get();
        Task<Driver?> Get(int id);
        Task<int> Create(Driver driver);
        Task<int> Update(Driver driver);
        Task<int> Delete(int driverId);
    }
}
