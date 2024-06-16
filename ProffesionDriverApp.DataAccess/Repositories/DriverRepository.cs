using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class DriverRepository : EFTRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
