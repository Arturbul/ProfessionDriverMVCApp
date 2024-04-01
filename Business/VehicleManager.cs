using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        //GET
        public async Task<ICollection<Vehicle>> Get()
        {
            return await _vehicleRepository.Get();
        }

        public async Task<Vehicle?> Get(int id)
        {
            return await _vehicleRepository.Get(id);
        }

        //POST
        public async Task<int> Create(Vehicle vehicle)
        {
            return await _vehicleRepository.Create(vehicle);
        }

        public async Task<int> Update(Vehicle vehicle)
        {
            return await _vehicleRepository.Update(vehicle);
        }

        //DELETE
        public async Task<int> Delete(int vehicleId)
        {
            return await _vehicleRepository.Delete(vehicleId);
        }
    }
}
