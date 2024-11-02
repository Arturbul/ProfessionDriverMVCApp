using ProfessionDriverApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace ProfessionDriverApp.Domain.Models
{
    public class VehicleInspection : EntityBase, ICompanyScope
    {
        public int VehicleInspectionId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public int CompanyId { get; set; }
        public override object Key => VehicleInspectionId;
    }
}
