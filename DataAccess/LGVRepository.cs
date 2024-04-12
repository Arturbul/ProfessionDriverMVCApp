using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class LGVRepository : EFTRepository<LargeGoodsVehicle>, ILGVRepository
    {
        public LGVRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
