using Domain.Models;

namespace DataAccess.Interface
{
    public interface IVehicleInspectionRepository
    {
        Task<ICollection<VehicleInspection>> GetVehicleInspection();
        Task<VehicleInspection?> GetVehicleInspection(int id);
        Task<int> PostVehicleInspection(VehicleInspection vehicleInspection);
        Task<int> DeleteVehicleInspection(int vehicleInspectionId);
    }
}
