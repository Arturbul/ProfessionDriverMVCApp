using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class DriverWorkLogDetailManager : IDriverWorkLogDetailManager
    {
        private readonly IDriverWorkLogDetailRepository _workLogEntryRepository;
        public DriverWorkLogDetailManager(IDriverWorkLogDetailRepository workLogEntryRepository)
        {
            _workLogEntryRepository = workLogEntryRepository;
        }

        //GET
        public async Task<ICollection<DriverWorkLogDetail>> Get()
        {
            return await _workLogEntryRepository.Get();
        }

        public async Task<DriverWorkLogDetail?> Get(Guid detailId)
        {
            return await _workLogEntryRepository.Get(detailId);
        }

        //POST
        public async Task<Guid> Create(DriverWorkLogDetail detail)
        {
            return await _workLogEntryRepository.Create(detail);
        }
        public async Task<Guid> Update(DriverWorkLogDetail detail)
        {
            return await _workLogEntryRepository.Update(detail);
        }

        //DELETE
        public async Task<Guid> Delete(Guid LogId)
        {
            return await _workLogEntryRepository.Delete(LogId);
        }
    }
}
