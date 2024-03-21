using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class VehicleInspectionManager : IVehicleInspectionManager
    {
        private readonly IVehicleInspectionRepository _vehicleInspectionRepository;
        public VehicleInspectionManager(IVehicleInspectionRepository repository)
        {
            _vehicleInspectionRepository = repository;
        }
        //GET
        public async Task<ICollection<VehicleInspection>> GetVehicleInspection()
        {
            return await _vehicleInspectionRepository.GetVehicleInspection();
        }

        public async Task<VehicleInspection?> GetVehicleInspection(int id)
        {
            return await _vehicleInspectionRepository.GetVehicleInspection(id);
        }

        //POST
        public async Task<int> PostVehicleInspection(VehicleInspection vehicleInspection)
        {
            return await _vehicleInspectionRepository.PostVehicleInspection(vehicleInspection);
        }

        //DELETE
        public async Task<int> DeleteVehicleInspection(int vehicleInspectionId)
        {
            return await _vehicleInspectionRepository.DeleteVehicleInspection(vehicleInspectionId);
        }
    }
}
