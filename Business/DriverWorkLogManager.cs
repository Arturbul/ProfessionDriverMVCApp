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
        public async Task<IEnumerable<DriverWorkLog>> Get()
        {
            return await _workLogRepository.Get();
        }

        public async Task<DriverWorkLog?> Get(Guid logId)
        {
            return await _workLogRepository.Get(logId);
        }

        // POST
        public async Task<DriverWorkLog> Create(DriverWorkLog log)
        {
            return await _workLogRepository.Create(log);
        }

        public async Task<DriverWorkLog> Update(DriverWorkLog log)
        {
            return await _workLogRepository.Update(log);
        }
        // DELETE
        public async Task<int> Delete(Guid logId)
        {
            var log = await _workLogRepository.Get(logId);
            if (log == null)
            {
                return 0;
            }
            return await _workLogRepository.Delete(log);
        }
    }
}
