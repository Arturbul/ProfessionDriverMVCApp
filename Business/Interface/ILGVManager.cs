using Domain.Models;

namespace Business.Interface
{
    public interface ILGVManager
    {
        Task<IEnumerable<LargeGoodsVehicle>> Get();
        Task<LargeGoodsVehicle?> Get(int id);
        Task<LargeGoodsVehicle> Create(LargeGoodsVehicle lgv);
        Task<LargeGoodsVehicle> Update(LargeGoodsVehicle lgv);
        Task<int> Delete(int lgvId);
    }
}
