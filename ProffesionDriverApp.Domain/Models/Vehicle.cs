using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class Vehicle
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public int? EntityId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? VehicleInsuranceId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public Entity? Entity { get; set; }
        public VehicleInsurance? VehicleInsurance { get; set; }
        public VehicleInspection? VehicleInspection { get; set; }
    }
}
