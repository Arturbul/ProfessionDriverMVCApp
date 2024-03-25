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
        public Guid? DriverWorkLogDetailId { get; set; }

        public Driver Driver { get; set; } = null!;
        public DriverWorkLogDetail? DriverWorkLogDetail { get; set; }
    }
}
//Driver Pauses
//prop PauseLogArr?

//Location Arr
//prop Location Arr?