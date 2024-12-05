using ProfessionDriverApp.Application.Requests.Create;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<int> CreateVehicle(CreateVehicleRequest request);
    }
}
