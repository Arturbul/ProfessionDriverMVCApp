namespace Domain.ViewModels
{
    public class VehicleInsuranceViewModel
    {
        public int VehicleInsuranceId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public InsurancePolicyViewModel OC_Policy { get; set; } = null!;
        public InsurancePolicyViewModel? AC_Policy { get; set; }
    }
}
