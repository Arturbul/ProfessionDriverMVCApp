using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class DriverWorkLogEntryRepository : EFTRepository<DriverWorkLogEntry>, IDriverWorkLogEntryRepository
    {
        public DriverWorkLogEntryRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
