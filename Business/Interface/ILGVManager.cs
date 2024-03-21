using Domain.Models;

namespace Business.Interface
{
    public interface ILGVManager
    {
        Task<ICollection<LargeGoodsVehicle>> GetLargeGoodsVehicle();
        Task<LargeGoodsVehicle?> GetLargeGoodsVehicle(int id);
        Task<int> PostLargeGoodsVehicle(LargeGoodsVehicle lgv);
        Task<int> DeleteLargeGoodsVehicle(int lgvId);
    }
}
