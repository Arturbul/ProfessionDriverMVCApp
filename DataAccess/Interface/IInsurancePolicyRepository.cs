using Domain.Models;

namespace DataAccess.Interface
{
    public interface IInsurancePolicyRepository
    {
        Task<ICollection<InsurancePolicy>> Get();
        Task<InsurancePolicy?> Get(int id);
        Task<int> Create(InsurancePolicy insurancePolicy);
        Task<int> Update(InsurancePolicy insurancePolicy);
        Task<int> Delete(int insurancePolicyId);
    }
}
