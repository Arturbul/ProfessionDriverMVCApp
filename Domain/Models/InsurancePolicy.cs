using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class InsurancePolicy
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PolicyId is required, must be greater than 0.")]
        public int InsurancePolicyId { get; set; }

        public string RegistrationNumber { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public string? Owner { get; set; }
        public string? AccountNumber { get; set; }
    }
}
