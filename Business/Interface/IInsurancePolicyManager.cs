using Domain.Models;

namespace Business.Interface
{
    public interface IInsurancePolicyManager
    {
        Task<ICollection<InsurancePolicy>> Get();
        Task<InsurancePolicy?> Get(int id);
        Task<int> Create(InsurancePolicy insurancePolicy);
        Task<int> Update(InsurancePolicy insurancePolicy);
        Task<int> Delete(int insurancePolicyId);
    }
}
