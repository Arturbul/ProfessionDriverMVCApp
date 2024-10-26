using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class DriverWorkLog : EntityBase
    {
        public Guid DriverWorkLogId { get; set; }
        public int DriverId { get; set; }
        public LargeGoodsVehicle LargeGoodsVehicle { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
        [ForeignKey("StartEntryId")]
        public DriverWorkLogEntry StartEntry { get; set; } = null!;

        [ForeignKey("EndEntryId")]
        public DriverWorkLogEntry? EndEntry { get; set; }
        public override object Key => DriverWorkLogId;
    }
}
//Driver Pauses
//prop PauseLogArr?

//Location Arr
//prop Location Arr?