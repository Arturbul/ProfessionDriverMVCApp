using ProfessionDriverApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class DriverWorkLog : EntityBase, ICompanyScope
    {
        public Guid DriverWorkLogId { get; set; }
        public TransportUnit TransportUnit { get; set; } = null!;
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        [ForeignKey("StartEntryId")]
        public DriverWorkLogEntry StartEntry { get; set; } = null!;

        [ForeignKey("EndEntryId")]
        public DriverWorkLogEntry? EndEntry { get; set; }
        public int CompanyId { get; set; }
        public override object Key => DriverWorkLogId;
    }
}
//Driver Pauses
//prop PauseLogArr?

//Location Arr
//prop Location Arr?