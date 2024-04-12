using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class VehicleInsurance
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleInsuranceId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public int VehicleId;

        public Vehicle Vehicle { get; set; } = null!;
        public InsurancePolicy OC_Policy { get; set; } = null!;
        public InsurancePolicy? AC_Policy { get; set; }
    }
}