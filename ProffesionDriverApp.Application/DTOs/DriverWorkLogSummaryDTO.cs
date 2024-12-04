namespace ProfessionDriverApp.Application.DTOs
{
    public class DriverWorkLogSummaryDTO
    {
        public Guid DriverWorkLogId { get; set; }
        public string? StartPlace { get; set; }
        public string? EndPlace { get; set; }
        public float? TotalDistance { get; set; }
        public float? TotalHours { get; set; }
        public string? VehicleNumber { get; set; }
        public string? TrailerNumber { get; set; }
        public string? VehicleBrand { get; set; }
    }
}
