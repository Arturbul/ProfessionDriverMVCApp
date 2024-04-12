using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

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
