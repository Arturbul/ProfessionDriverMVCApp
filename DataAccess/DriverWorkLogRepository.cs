using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class DriverWorkLogRepository : EFTRepository<DriverWorkLog>, IDriverWorkLogRepository
    {
        public DriverWorkLogRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
