using Domain.Models;

namespace Business.Interface
{
    public interface IDriverManager
    {
        Task<ICollection<Driver>> GetDriver();
        Task<Driver?> GetDriver(int id);
        Task<int> PostDriver(Driver driver);
        Task<int> DeleteDriver(int driverId);
    }
}
