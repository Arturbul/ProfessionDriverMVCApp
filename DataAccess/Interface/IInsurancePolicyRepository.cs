using Domain.Models;

namespace DataAccess.Interface
{
    public interface IInsurancePolicyRepository
    {
        Task<ICollection<InsurancePolicy>> GetInsurancePolicy();
        Task<InsurancePolicy?> GetInsurancePolicy(int id);
        Task<int> PostInsurancePolicy(InsurancePolicy insurancePolicy);
        Task<int> DeleteInsurancePolicy(int insurancePolicyId);
    }
}
