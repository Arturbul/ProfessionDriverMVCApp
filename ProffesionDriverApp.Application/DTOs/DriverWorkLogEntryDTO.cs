namespace ProfessionDriverApp.Application.DTOs
{
    public class DriverWorkLogEntryDTO
    {
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
    }
}
