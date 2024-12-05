using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<int> CreateVehicle(CreateVehicleRequest request);
        Task<VehicleDTO?> GetVehicle(string registrationNumber);
        Task<IList<VehicleDTO>?> GetVehicles(string? companyName);
    }
}
