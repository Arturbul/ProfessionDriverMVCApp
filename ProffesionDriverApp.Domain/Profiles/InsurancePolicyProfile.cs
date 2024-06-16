using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class InsurancePolicyProfile : Profile
    {
        public InsurancePolicyProfile()
        {
            CreateMap<InsurancePolicy, InsurancePolicyViewModel>();
            CreateMap<InsurancePolicyViewModel, InsurancePolicy>();
        }
    }
}
