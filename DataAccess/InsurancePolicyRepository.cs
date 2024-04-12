using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class InsurancePolicyRepository : EFTRepository<InsurancePolicy>, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
