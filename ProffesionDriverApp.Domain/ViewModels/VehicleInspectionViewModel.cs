namespace ProfessionDriverApp.Domain.ViewModels
{
    public class VehicleInspectionViewModel
    {
        public int VehicleInspectionId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
