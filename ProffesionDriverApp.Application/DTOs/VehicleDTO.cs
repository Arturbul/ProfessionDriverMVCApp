namespace ProfessionDriverApp.Application.DTOs
{
    public class VehicleDTO
    {
        public string RegistrationNumber { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? VehicleInsuranceId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public bool IsLGV { get; set; } = false;
        public DateOnly? TachoExpiryDate { get; set; }
    }
}
