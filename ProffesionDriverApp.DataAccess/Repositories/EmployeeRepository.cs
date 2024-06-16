using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class EmployeeRepository : EFTRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
