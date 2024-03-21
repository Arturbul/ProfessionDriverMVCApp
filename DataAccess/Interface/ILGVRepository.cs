using Domain.Models;

namespace DataAccess.Interface
{
    public interface ILGVRepository
    {
        Task<ICollection<LargeGoodsVehicle>> GetLargeGoodsVehicle();
        Task<LargeGoodsVehicle?> GetLargeGoodsVehicle(int id);
        Task<int> PostLargeGoodsVehicle(LargeGoodsVehicle lgv);
        Task<int> DeleteLargeGoodsVehicle(int lgvId);
    }
}
