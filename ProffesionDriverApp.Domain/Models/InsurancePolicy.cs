using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class InsurancePolicy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Range(1, int.MaxValue)]
        public int InsurancePolicyId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public string? Owner { get; set; }
        public string? AccountNumber { get; set; }
    }
}
