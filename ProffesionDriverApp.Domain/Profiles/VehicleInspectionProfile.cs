using AutoMapper;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace Domain.Profiles
{
    public class VehicleInspectionProfile : Profile
    {
        public VehicleInspectionProfile()
        {
            CreateMap<VehicleInspection, VehicleInspectionViewModel>();
            CreateMap<VehicleInspectionViewModel, VehicleInspection>();
        }
    }
}
