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
        public async Task<IEnumerable<DriverWorkLogEntry>> Get()
        {
            return await _workLogEntryRepository.Get();
        }

        public async Task<DriverWorkLogEntry?> Get(Guid logId)
        {
            return await _workLogEntryRepository.Get(logId);
        }

        //POST
        public async Task<DriverWorkLogEntry> Create(DriverWorkLogEntry log)
        {
            return await _workLogEntryRepository.Create(log);
        }

        public async Task<DriverWorkLogEntry> Update(DriverWorkLogEntry log)
        {
            return await _workLogEntryRepository.Update(log);
        }

        //DELETE
        public async Task<int> Delete(Guid logId)
        {
            var log = await _workLogEntryRepository.Get(logId);
            if (log == null)
            {
                return 0;
            }
            return await _workLogEntryRepository.Delete(log);
        }
    }
}
