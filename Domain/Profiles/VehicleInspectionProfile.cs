using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

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
