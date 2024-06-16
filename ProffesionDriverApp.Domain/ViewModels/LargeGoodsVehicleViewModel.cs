namespace ProfessionDriverApp.Domain.ViewModels
{
    public class LargeGoodsVehicleViewModel
    {
        public int LargeGoodsVehicleId { get; set; }
        public int VehicleId { get; set; }
        public int? TrailerId { get; set; }
        public DateOnly? TachoExpiryDate { get; set; }
        public VehicleViewModel Vehicle { get; set; } = null!;
        public VehicleViewModel? Trailer { get; set; }
        //public IList<DriverWorkLog>? DriverWorkLogs { get; set; }
    }
}
