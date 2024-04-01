using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class DriverWorkLogEntryManager : IDriverWorkLogEntryManager
    {
        private readonly IDriverWorkLogEntryRepository _workLogEntryRepository;
        public DriverWorkLogEntryManager(IDriverWorkLogEntryRepository workLogEntryRepository)
        {
            _workLogEntryRepository = workLogEntryRepository;
        }

        //GET
        public async Task<ICollection<DriverWorkLogEntry>> Get()
        {
            return await _workLogEntryRepository.Get();
        }

        public async Task<DriverWorkLogEntry?> Get(Guid logId)
        {
            return await _workLogEntryRepository.Get(logId);
        }

        //POST
        public async Task<Guid> Create(DriverWorkLogEntry log)
        {
            return await _workLogEntryRepository.Create(log);
        }

        public async Task<Guid> Update(DriverWorkLogEntry log)
        {
            return await _workLogEntryRepository.Update(log);
        }

        //DELETE
        public async Task<Guid> Delete(Guid LogId)
        {
            return await _workLogEntryRepository.Delete(LogId);
        }
    }
}
