using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public interface IVehicleInspectionService
    {
        Task<IEnumerable<VehicleInspection>> Get();
        Task<VehicleInspection?> Get(int id);
        Task<VehicleInspection> Create(VehicleInspection vehicleInspection);
        Task<VehicleInspection> Update(VehicleInspection vehicleInspection);
        Task<int> Delete(int vehicleInspectionId);
    }
}
