using Domain.ViewModels;

namespace Business.Interface
{
    public interface IDriverManager
    {
        Task<IEnumerable<DriverViewModel>> Get();
        Task<DriverViewModel?> Get(int id);
        Task<int> Create(DriverViewModel driverDTO);
        Task<int> Update(DriverViewModel driverDTO);
        Task<int> Delete(int driverId);
    }
}
