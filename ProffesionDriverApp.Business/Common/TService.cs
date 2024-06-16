using AutoMapper;
using ProfessionDriverApp.DataAccess.Common;

namespace ProfessionDriverApp.Business.Common
{
    public abstract class TService<T, TSearcher, TRepository, IdType> : ITService<T, TSearcher, IdType>
        where T : class, new()
        where TSearcher : class, new()
        where TRepository : ITRepository<T>
    {
        private readonly IMapper _mapper;
        protected readonly TRepository _repository;
        public TService(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //GET
        public abstract IEnumerable<T> Get(TSearcher searcher);

        public abstract T? GetSingle(IdType id);

        //POST
        public async Task<T> Create(T entity)
        {
            var result = await _repository.Create(entity);

            return result;
        }
        public async Task<T> Update(T entity)
        {
            var result = await _repository.Update(entity);

            return result;
        }

        //DELETE
        public abstract Task<int> Delete(IdType entityId);
    }
}
