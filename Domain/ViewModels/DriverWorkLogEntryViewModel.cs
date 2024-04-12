namespace Domain.ViewModels
{
    public class DriverWorkLogEntryViewModel
    {
        public Guid DriverWorkLogEntryId { get; set; }
        public int DriverId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
        public DriverViewModel Driver { get; set; } = null!;
        public Guid? DriverWorkLogDetailId { get; set; }
        //public DriverWorkLogDetail? DriverWorkLogDetail { get; set; }
    }
}
