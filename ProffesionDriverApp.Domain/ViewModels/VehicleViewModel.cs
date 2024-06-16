namespace ProfessionDriverApp.Domain.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public int? EntityId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? VehicleInsuranceId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public EntityViewModel? Entity { get; set; }
        public VehicleInsuranceViewModel? VehicleInsurance { get; set; }
        public VehicleInspectionViewModel? VehicleInspection { get; set; }
    }
}
