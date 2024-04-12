namespace Domain.ViewModels
{
    public class InsurancePolicyViewModel
    {
        public int InsurancePolicyId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public string? Owner { get; set; }
        public string? AccountNumber { get; set; }
    }
}
