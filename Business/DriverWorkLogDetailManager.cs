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
        public async Task<ICollection<DriverWorkLogDetail>> GetDriverWorkLogDetail()
        {
            return await _workLogEntryRepository.GetDriverWorkLogDetail();
        }

        public async Task<DriverWorkLogDetail?> GetDriverWorkLogDetail(Guid detailId)
        {
            return await _workLogEntryRepository.GetDriverWorkLogDetail(detailId);
        }

        //POST
        public async Task<Guid> PostDriverWorkLogDetail(DriverWorkLogDetail detail)
        {
            return await _workLogEntryRepository.PostDriverWorkLogDetail(detail);
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLogDetail(Guid LogId)
        {
            return await _workLogEntryRepository.DeleteDriverWorkLogDetail(LogId);
        }
    }
}
