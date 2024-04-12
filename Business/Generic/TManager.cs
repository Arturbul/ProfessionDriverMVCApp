using AutoMapper;
using Business.Generic.Interface;
using DataAccess.Generic.Interface;

namespace Business.Generic
{
    public class TManager<T, TViewModel, TRepository> : ITManager<T, TViewModel>
        where T : class, new()
        where TViewModel : class
        where TRepository : ITRepository<T>
    {
        private readonly IMapper _mapper;
        private readonly TRepository _repository;
        public TManager(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //GET
        public async Task<IEnumerable<TViewModel>> Get()
        {
            var entities = await _repository.Get();
            return _mapper.Map<IEnumerable<TViewModel>>(entities);
        }

        public async Task<TViewModel?> Get<IdType>(IdType id)
        {
            var entity = await _repository.Get(id);
            return _mapper?.Map<TViewModel>(entity);
        }

        //POST
        public async Task<TViewModel> Create(TViewModel entityViewModel)
        {
            var entity = _mapper.Map<T>(entityViewModel);
            var result = await _repository.Create(entity);

            return _mapper.Map<TViewModel>(result);
        }
        public async Task<TViewModel> Update(TViewModel entityViewModel)
        {
            var entity = _mapper.Map<T>(entityViewModel);
            var result = await _repository.Update(entity);

            return _mapper.Map<TViewModel>(result);
        }

        //DELETE
        public async Task<int> Delete<IdType>(IdType entityId)
        {
            var entity = await _repository.Get(entityId);
            if (entity == null)
            {
                return 0;
            }
            return await _repository.Delete(entity);
        }
    }
}
