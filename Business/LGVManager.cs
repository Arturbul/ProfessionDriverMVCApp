using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class LGVManager : ILGVManager
    {
        private readonly ILGVRepository _lgvRepository;
        public LGVManager(ILGVRepository lgvRepository)
        {
            _lgvRepository = lgvRepository;
        }

        //GET
        public async Task<ICollection<LargeGoodsVehicle>> GetLargeGoodsVehicle()
        {
            return await _lgvRepository.GetLargeGoodsVehicle();
        }

        public async Task<LargeGoodsVehicle?> GetLargeGoodsVehicle(int id)
        {
            return await _lgvRepository.GetLargeGoodsVehicle(id);
        }

        //POST
        public async Task<int> PostLargeGoodsVehicle(LargeGoodsVehicle lgv)
        {
            return await _lgvRepository.PostLargeGoodsVehicle(lgv);
        }

        //DELETE
        public async Task<int> DeleteLargeGoodsVehicle(int lgvId)
        {
            return await _lgvRepository.DeleteLargeGoodsVehicle(lgvId);
        }
    }
}
