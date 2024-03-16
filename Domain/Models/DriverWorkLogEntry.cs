using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DriverWorkLogEntry
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DriverWorkLogEntryId { get; set; }
        public Guid? DriverWorkLogId { get; set; } // Nullable foreign key
        public int DriverId { get; set; }
        [StringLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        [Required]
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
        public Driver Driver { get; set; } = null!;

        public DriverWorkLog? DriverWorkLog { get; set; }
    }
}
