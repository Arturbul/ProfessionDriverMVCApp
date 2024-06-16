using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class InsurancePolicyRepository : EFTRepository<InsurancePolicy>, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
