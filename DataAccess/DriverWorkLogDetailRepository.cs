using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class DriverWorkLogDetailRepository : EFTRepository<DriverWorkLogDetail>, IDriverWorkLogDetailRepository
    {
        public DriverWorkLogDetailRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
