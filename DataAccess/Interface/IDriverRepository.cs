using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverRepository
    {
        Task<ICollection<Driver>> GetDriver();
        Task<Driver?> GetDriver(int id);
        Task<int> PostDriver(Driver driver);
        Task<int> DeleteDriver(int driverId);
    }
}
