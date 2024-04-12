﻿using Business.Interface;
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
        public async Task<IEnumerable<DriverWorkLogDetail>> Get()
        {
            return await _workLogEntryRepository.Get();
        }

        public async Task<DriverWorkLogDetail?> Get(Guid detailId)
        {
            return await _workLogEntryRepository.Get(detailId);
        }

        //POST
        public async Task<DriverWorkLogDetail> Create(DriverWorkLogDetail detail)
        {
            return await _workLogEntryRepository.Create(detail);
        }
        public async Task<DriverWorkLogDetail> Update(DriverWorkLogDetail detail)
        {
            return await _workLogEntryRepository.Update(detail);
        }

        //DELETE
        public async Task<int> Delete(Guid LogId)
        {
            var dwlg = await _workLogEntryRepository.Get(LogId);
            if (dwlg == null)
            {
                return 0;
            }
            return await _workLogEntryRepository.Delete(dwlg);
        }
    }
}
