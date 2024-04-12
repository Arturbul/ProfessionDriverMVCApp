using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class VehicleInspectionRepository : EFTRepository<VehicleInspection>, IVehicleInspectionRepository
    {
        public VehicleInspectionRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
