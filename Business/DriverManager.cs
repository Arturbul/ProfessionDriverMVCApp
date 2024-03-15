using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class DriverManager : IDriverManager
    {
        private readonly IDriverRepository _driverRepository;
        public DriverManager(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        //GET
        public async Task<ICollection<Driver>> GetDriver()
        {
            return await _driverRepository.GetDriver();
        }

        public async Task<Driver?> GetDriver(int id)
        {
            return await _driverRepository.GetDriver(id);
        }

        //POST
        public async Task<int> PostDriver(Driver driver)
        {
            return await _driverRepository.PostDriver(driver);
        }

        //DELETE
        public async Task<int> DeleteDriver(int driverId)
        {
            return await _driverRepository.DeleteDriver(driverId);
        }
    }
}
