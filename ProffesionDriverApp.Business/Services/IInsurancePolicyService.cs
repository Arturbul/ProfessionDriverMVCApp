using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public interface IInsurancePolicyService
    {
        Task<IEnumerable<InsurancePolicy>> Get();
        Task<InsurancePolicy?> Get(int id);
        Task<InsurancePolicy> Create(InsurancePolicy insurancePolicy);
        Task<InsurancePolicy> Update(InsurancePolicy insurancePolicy);
        Task<int> Delete(int insurancePolicyId);
    }
}
