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
        public async Task<IEnumerable<LargeGoodsVehicle>> Get()
        {
            return await _lgvRepository.Get();
        }

        public async Task<LargeGoodsVehicle?> Get(int id)
        {
            return await _lgvRepository.Get(id);
        }

        //POST
        public async Task<LargeGoodsVehicle> Create(LargeGoodsVehicle lgv)
        {
            return await _lgvRepository.Create(lgv);
        }

        public async Task<LargeGoodsVehicle> Update(LargeGoodsVehicle lgv)
        {
            return await _lgvRepository.Update(lgv);
        }

        //DELETE
        public async Task<int> Delete(int lgvId)
        {
            var lgv = await _lgvRepository.Get(lgvId);
            if (lgv == null)
            {
                return 0;
            }
            return await _lgvRepository.Delete(lgv);
        }
    }
}
