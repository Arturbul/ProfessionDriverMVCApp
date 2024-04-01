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
        public async Task<ICollection<LargeGoodsVehicle>> Get()
        {
            return await _lgvRepository.Get();
        }

        public async Task<LargeGoodsVehicle?> Get(int id)
        {
            return await _lgvRepository.Get(id);
        }

        //POST
        public async Task<int> Create(LargeGoodsVehicle lgv)
        {
            return await _lgvRepository.Create(lgv);
        }

        public async Task<int> Update(LargeGoodsVehicle lgv)
        {
            return await _lgvRepository.Update(lgv);
        }

        //DELETE
        public async Task<int> Delete(int lgvId)
        {
            return await _lgvRepository.Delete(lgvId);
        }
    }
}
