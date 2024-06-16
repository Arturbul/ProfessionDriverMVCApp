using ProfessionDriverApp.DataAccess.Repositories;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        public InsurancePolicyService(IInsurancePolicyRepository repository)
        {
            _insurancePolicyRepository = repository;
        }
        //GET
        public async Task<IEnumerable<InsurancePolicy>> Get()
        {
            return await _insurancePolicyRepository.Get();
        }

        public async Task<InsurancePolicy?> Get(int id)
        {
            return await _insurancePolicyRepository.Get(id);
        }

        //POST
        public async Task<InsurancePolicy> Create(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyRepository.Create(insurancePolicy);
        }
        public async Task<InsurancePolicy> Update(InsurancePolicy insurancePolicy)
        {
            return await _insurancePolicyRepository.Update(insurancePolicy);
        }

        //DELETE
        public async Task<int> Delete(int insurancePolicyId)
        {
            var policy = await _insurancePolicyRepository.Get(insurancePolicyId);
            if (policy == null)
            {
                return 0;
            }
            return await _insurancePolicyRepository.Delete(policy);
        }
    }
}
