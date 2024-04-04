using Domain.Models.DTO;

namespace Business.Interface
{
    public interface IDriverManager
    {
        Task<IEnumerable<DriverDTO?>> Get();
        Task<DriverDTO?> Get(int id);
        Task<int> Create(DriverDTO driverDTO);
        Task<int> Update(DriverDTO driverDTO);
        Task<int> Delete(int driverId);
    }
}
