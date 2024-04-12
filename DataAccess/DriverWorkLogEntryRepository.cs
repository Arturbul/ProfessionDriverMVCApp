using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class DriverWorkLogEntryRepository : EFTRepository<DriverWorkLogEntry>, IDriverWorkLogEntryRepository
    {
        public DriverWorkLogEntryRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
