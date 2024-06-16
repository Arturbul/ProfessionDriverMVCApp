using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class VehicleRepository : EFTRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
