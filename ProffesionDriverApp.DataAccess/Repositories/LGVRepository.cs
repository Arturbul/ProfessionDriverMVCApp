using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class LGVRepository : EFTRepository<LargeGoodsVehicle>, ILGVRepository
    {
        public LGVRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
