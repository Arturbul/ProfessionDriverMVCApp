using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Domain.Models
{
    public class DriverWorkLogEntry : EntityBase
    {
        public Guid DriverWorkLogEntryId { get; set; }
        public int DriverId { get; set; }
        [StringLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public string? RegistrationNumberTrailer { get; set; }
        [Required]
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
        public Driver Driver { get; set; } = null!;
        public override object Key => DriverWorkLogEntryId;
    }
}
