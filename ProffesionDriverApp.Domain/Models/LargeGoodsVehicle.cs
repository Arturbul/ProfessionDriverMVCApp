namespace ProfessionDriverApp.Domain.Models
{
    public class LargeGoodsVehicle : Vehicle
    {
        public int LargeGoodsVehicleId { get; set; }
        public DateOnly? TachoExpiryDate { get; set; }
        public IList<DriverWorkLog>? DriverWorkLogs { get; set; }
        public override object Key => LargeGoodsVehicleId;
    }
}
