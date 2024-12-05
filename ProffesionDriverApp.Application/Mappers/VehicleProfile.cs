using AutoMapper;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Mappers
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleRequest, Vehicle>().ReverseMap();
            CreateMap<CreateVehicleRequest, LargeGoodsVehicle>().ReverseMap();
        }
    }
}
