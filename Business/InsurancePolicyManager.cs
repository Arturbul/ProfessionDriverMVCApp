using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class InsurancePolicyManager : IInsurancePolicyManager
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        public InsurancePolicyManager(IInsurancePolicyRepository repository)
        {
            _insurancePolicyRepository = repository;
        }
        //GET
        public async Task<ICollection<InsurancePolicy>> GetInsurancePolicy()
        {
            return await _insurancePolicyRepository.GetInsurancePolicy();
        }

        public async Task<InsurancePolicy?> GetInsurancePolicy(int id)
        {
            return await _insurancePolicyRepository.GetInsurancePolicy(id);
        }

        //POST
        public async Task<int> PostInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyRepository.PostInsurancePolicy(insurancePolicy);
        }

        //DELETE
        public async Task<int> DeleteInsurancePolicy(int insurancePolicyId)
        {
            return await _insurancePolicyRepository.DeleteInsurancePolicy(insurancePolicyId);
        }
    }
}
