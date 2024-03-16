using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DriverWorkLog
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DriverWorkLogId { get; set; }
        public int DriverId { get; set; }
        public Guid StartDriverWorkLogEntryId { get; set; } //
        public Guid EndDriverWorkLogEntryId { get; set; } //
        public Driver Driver { get; set; } = null!;
    }
}
//Driver Pauses
//prop PauseLogArr?

//Location Arr
//prop Location Arr?