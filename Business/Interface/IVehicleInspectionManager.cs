using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleInspectionManager
    {
        Task<ICollection<VehicleInspection>> GetVehicleInspection();
        Task<VehicleInspection?> GetVehicleInspection(int id);
        Task<int> PostVehicleInspection(VehicleInspection vehicleInspection);
        Task<int> DeleteVehicleInspection(int vehicleInspectionId);
    }
}
