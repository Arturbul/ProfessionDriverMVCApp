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
        public LargeGoodsVehicle LargeGoodsVehicle { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
        [ForeignKey("StartEntryId")]
        public DriverWorkLogEntry StartEntry { get; set; } = null!;

        [ForeignKey("EndEntryId")]
        public DriverWorkLogEntry? EndEntry { get; set; }
    }
}
//Driver Pauses
//prop PauseLogArr?

//Location Arr
//prop Location Arr?