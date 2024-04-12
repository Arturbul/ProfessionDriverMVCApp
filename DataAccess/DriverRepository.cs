using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class DriverRepository : EFTRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
