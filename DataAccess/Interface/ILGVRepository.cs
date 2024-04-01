using Domain.Models;

namespace DataAccess.Interface
{
    public interface ILGVRepository
    {
        Task<ICollection<LargeGoodsVehicle>> Get();
        Task<LargeGoodsVehicle?> Get(int id);
        Task<int> Create(LargeGoodsVehicle lgv);
        Task<int> Update(LargeGoodsVehicle lgv);
        Task<int> Delete(int lgvId);
    }
}
