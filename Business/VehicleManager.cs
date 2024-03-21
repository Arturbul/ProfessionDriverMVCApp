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
        public async Task<ICollection<Vehicle>> GetVehicle()
        {
            return await _vehicleRepository.GetVehicle();
        }

        public async Task<Vehicle?> GetVehicle(int id)
        {
            return await _vehicleRepository.GetVehicle(id);
        }

        //POST
        public async Task<int> PostVehicle(Vehicle vehicle)
        {
            return await _vehicleRepository.PostVehicle(vehicle);
        }

        //DELETE
        public async Task<int> DeleteVehicle(int vehicleId)
        {
            return await _vehicleRepository.DeleteVehicle(vehicleId);
        }
    }
}
