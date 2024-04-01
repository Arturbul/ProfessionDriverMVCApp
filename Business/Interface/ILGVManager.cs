using Domain.Models;

namespace Business.Interface
{
    public interface ILGVManager
    {
        Task<ICollection<LargeGoodsVehicle>> Get();
        Task<LargeGoodsVehicle?> Get(int id);
        Task<int> Create(LargeGoodsVehicle lgv);
        Task<int> Update(LargeGoodsVehicle lgv);
        Task<int> Delete(int lgvId);
    }
}
