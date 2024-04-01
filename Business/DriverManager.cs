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
        public async Task<ICollection<Driver>> Get()
        {
            return await _driverRepository.Get();
        }

        public async Task<Driver?> Get(int id)
        {
            return await _driverRepository.Get(id);
        }

        //POST
        public async Task<int> Create(Driver driver)
        {
            return await _driverRepository.Create(driver);
        }
        public async Task<int> Update(Driver driver)
        {
            return await _driverRepository.Update(driver);
        }

        //DELETE
        public async Task<int> Delete(int driverId)
        {
            return await _driverRepository.Delete(driverId);
        }
    }
}
