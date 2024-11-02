using ProfessionDriverApp.Domain.Interfaces;

namespace ProfessionDriverApp.Domain.Models
{
    public class LargeGoodsVehicle : EntityBase, ICompanyScope
    {
        public int LargeGoodsVehicleId { get; set; }
        public int VehicleId { get; set; }
        public int? TrailerId { get; set; }
        public DateOnly? TachoExpiryDate { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public Vehicle? Trailer { get; set; }
        public IList<DriverWorkLog>? DriverWorkLogs { get; set; }
        public int CompanyId { get; set; }
        public override object Key => LargeGoodsVehicleId;
    }
}
