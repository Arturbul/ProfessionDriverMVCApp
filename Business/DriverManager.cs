using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.Models.DTO;

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
        public async Task<IEnumerable<DriverDTO?>> Get()
        {
            var drivers = await _driverRepository.Get();
            return drivers.Select(d => (DriverDTO?)d);
        }

        public async Task<DriverDTO?> Get(int id)
        {
            var driver = (DriverDTO?)await _driverRepository.Get(id);
            return driver;
        }

        //POST
        public async Task<int> Create(DriverDTO driverDTO)
        {
            var driver = (Driver?)driverDTO;
            if (driver == null)
            {
                return 0;
            }
            return await _driverRepository.Create(driver);
        }
        public async Task<int> Update(DriverDTO driverDTO)
        {
            var driver = (Driver?)driverDTO;
            if (driver == null)
            {
                return 0;
            }
            return await _driverRepository.Update(driver);
        }

        //DELETE
        public async Task<int> Delete(int driverId)
        {
            return await _driverRepository.Delete(driverId);
        }
    }
}
