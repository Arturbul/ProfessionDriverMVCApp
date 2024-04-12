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
        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await _vehicleRepository.Get();
        }

        public async Task<Vehicle?> Get(int id)
        {
            return await _vehicleRepository.Get(id);
        }

        //POST
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            return await _vehicleRepository.Create(vehicle);
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            return await _vehicleRepository.Update(vehicle);
        }

        //DELETE
        public async Task<int> Delete(int vehicleId)
        {
            var vehicle = await _vehicleRepository.Get(vehicleId);
            if (vehicle == null)
            {
                return 0;
            }
            return await _vehicleRepository.Delete(vehicle);
        }
    }
}
