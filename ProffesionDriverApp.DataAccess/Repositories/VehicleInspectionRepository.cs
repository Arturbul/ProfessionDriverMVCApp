using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class VehicleInspectionRepository : EFTRepository<VehicleInspection>, IVehicleInspectionRepository
    {
        public VehicleInspectionRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
