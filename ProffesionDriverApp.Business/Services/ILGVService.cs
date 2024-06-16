using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public interface ILGVService
    {
        Task<IEnumerable<LargeGoodsVehicle>> Get();
        Task<LargeGoodsVehicle?> Get(int id);
        Task<LargeGoodsVehicle> Create(LargeGoodsVehicle lgv);
        Task<LargeGoodsVehicle> Update(LargeGoodsVehicle lgv);
        Task<int> Delete(int lgvId);
    }
}
