using ProfessionDriverApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Domain.Models
{
    public class VehicleInsurance : EntityBase, ICompanyScope
    {
        public int VehicleInsuranceId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public InsurancePolicy OC_Policy { get; set; } = null!;
        public InsurancePolicy? AC_Policy { get; set; }
        public int CompanyId { get; set; }
        public override object Key => VehicleInsuranceId;
    }
}