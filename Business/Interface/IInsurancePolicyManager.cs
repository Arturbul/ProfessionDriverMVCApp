using Domain.Models;

namespace Business.Interface
{
    public interface IInsurancePolicyManager
    {
        Task<ICollection<InsurancePolicy>> GetInsurancePolicy();
        Task<InsurancePolicy?> GetInsurancePolicy(int id);
        Task<int> PostInsurancePolicy(InsurancePolicy insurancePolicy);
        Task<int> DeleteInsurancePolicy(int insurancePolicyId);
    }
}
