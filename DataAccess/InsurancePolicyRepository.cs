using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InsurancePolicyRepository : RepositoryBase, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(ProfessionDriverProjectContext context) : base(context) { }
        //GET
        public async Task<ICollection<InsurancePolicy>> GetInsurancePolicy()
        {
            using var context = this.Context;
            var insurancePolicy = await context
                                    .InsurancePolicies
                                    .AsNoTracking()
                                    .ToListAsync();

            return await Task.FromResult(insurancePolicy);
        }

        public async Task<InsurancePolicy?> GetInsurancePolicy(int id)
        {
            using var context = this.Context;
            var insurancePolicy = await context
                                    .InsurancePolicies
                                    .Where(e => e.InsurancePolicyId == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return await Task.FromResult(insurancePolicy);
        }

        //POST
        public async Task<int> PostInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            using var context = this.Context;
            context.InsurancePolicies.Add(insurancePolicy);
            await context.SaveChangesAsync();

            return insurancePolicy.InsurancePolicyId;
        }

        //DELETE
        public async Task<int> DeleteInsurancePolicy(int insurancePolicyId)
        {
            using var context = this.Context;
            var insurancePolicy = await context.InsurancePolicies.FindAsync(insurancePolicyId);
            if (insurancePolicy != null)
            {
                context.InsurancePolicies.Remove(insurancePolicy);
                await context.SaveChangesAsync();
                return insurancePolicy.InsurancePolicyId;
            }
            return 0;
        }

    }
}
