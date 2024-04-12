using Domain.Models;

namespace Business.Interface
{
    public interface IInsurancePolicyManager
    {
        Task<IEnumerable<InsurancePolicy>> Get();
        Task<InsurancePolicy?> Get(int id);
        Task<InsurancePolicy> Create(InsurancePolicy insurancePolicy);
        Task<InsurancePolicy> Update(InsurancePolicy insurancePolicy);
        Task<int> Delete(int insurancePolicyId);
    }
}
