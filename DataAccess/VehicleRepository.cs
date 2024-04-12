using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class VehicleRepository : EFTRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
