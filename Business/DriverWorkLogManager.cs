using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace DataAccess
{
    public class DriverWorkLogManager : IDriverWorkLogManager
    {
        private readonly IDriverWorkLogRepository _workLogRepository;

        public DriverWorkLogManager(IDriverWorkLogRepository workLogRepository)
        {
            _workLogRepository = workLogRepository;
        }

        // GET
        public async Task<ICollection<DriverWorkLog>> GetDriverWorkLog()
        {
            return await _workLogRepository.GetDriverWorkLog();
        }

        public async Task<DriverWorkLog?> GetDriverWorkLog(Guid logId)
        {
            return await _workLogRepository.GetDriverWorkLog(logId);
        }

        // POST
        public async Task<Guid> PostDriverWorkLog(DriverWorkLog log)
        {
            return await _workLogRepository.PostDriverWorkLog(log);
        }

        // DELETE
        public async Task<Guid> DeleteDriverWorkLog(Guid LogId)
        {
            return await _workLogRepository.DeleteDriverWorkLog(LogId);
        }
    }
}
