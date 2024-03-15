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
        public async Task<ICollection<DriverWorkLogEntry>> GetDriverWorkLogEntry()
        {
            return await _workLogEntryRepository.GetDriverWorkLogEntry();
        }

        public async Task<DriverWorkLogEntry?> GetDriverWorkLogEntry(Guid logId)
        {
            return await _workLogEntryRepository.GetDriverWorkLogEntry(logId);
        }

        //POST
        public async Task<Guid> PostDriverWorkLogEntry(DriverWorkLogEntry log)
        {
            return await _workLogEntryRepository.PostDriverWorkLogEntry(log);
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLogEntry(Guid LogId)
        {
            return await _workLogEntryRepository.DeleteDriverWorkLogEntry(LogId);
        }
    }
}
