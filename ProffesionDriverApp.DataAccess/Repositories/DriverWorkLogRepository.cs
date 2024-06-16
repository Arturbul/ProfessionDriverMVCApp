using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class DriverWorkLogRepository : EFTRepository<DriverWorkLog>, IDriverWorkLogRepository
    {
        public DriverWorkLogRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
