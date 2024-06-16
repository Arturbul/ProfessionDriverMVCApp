namespace ProfessionDriverApp.Domain.ViewModels
{
    public class DriverWorkLogViewModel
    {
        public Guid DriverWorkLogId { get; set; }
        public int DriverId { get; set; }
        public LargeGoodsVehicleViewModel LargeGoodsVehicle { get; set; } = null!;
        public DriverViewModel Driver { get; set; } = null!;
        public DriverWorkLogEntryViewModel StartEntry { get; set; } = null!;
        public DriverWorkLogEntryViewModel? EndEntry { get; set; }
    }
}
