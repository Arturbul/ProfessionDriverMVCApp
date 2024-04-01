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
        public async Task<ICollection<InsurancePolicy>> Get()
        {
            return await _insurancePolicyRepository.Get();
        }

        public async Task<InsurancePolicy?> Get(int id)
        {
            return await _insurancePolicyRepository.Get(id);
        }

        //POST
        public async Task<int> Create(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyRepository.Create(insurancePolicy);
        }
        public async Task<int> Update(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyRepository.Update(insurancePolicy);
        }

        //DELETE
        public async Task<int> Delete(int insurancePolicyId)
        {
            return await _insurancePolicyRepository.Delete(insurancePolicyId);
        }
    }
}
