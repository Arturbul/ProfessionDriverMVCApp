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
        public async Task<IEnumerable<VehicleInspection>> Get()
        {
            return await _vehicleInspectionRepository.Get();
        }

        public async Task<VehicleInspection?> Get(int id)
        {
            return await _vehicleInspectionRepository.Get(id);
        }

        //POST
        public async Task<VehicleInspection> Create(VehicleInspection vehicleInspection)
        {
            return await _vehicleInspectionRepository.Create(vehicleInspection);
        }
        public async Task<VehicleInspection> Update(VehicleInspection vehicleInspection)
        {
            return await _vehicleInspectionRepository.Update(vehicleInspection);
        }

        //DELETE
        public async Task<int> Delete(int vehicleInspectionId)
        {
            var inspection = await _vehicleInspectionRepository.Get(vehicleInspectionId);
            if (inspection == null)
            {
                return 0;
            }
            return await _vehicleInspectionRepository.Delete(inspection);
        }
    }
}
