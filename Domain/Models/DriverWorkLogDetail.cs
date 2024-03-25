using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DriverWorkLogDetail
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DriverWorkLogDetailId { get; set; }
        public Guid DriverWorkLogId { get; set; }
        public DriverWorkLog DriverWorkLog { get; set; } = null!;
        public ICollection<DriverWorkLogEntry>? DriverWorkLogEntries { get; set; }// <- aktualnie w projekcie
        /*public DriverWorkLogEntry StartWorkLogEntry { get; set; } = null!; //te wlasciwosci chce by byly
        public DriverWorkLogEntry EndWorkLogEntry { get; set; } = null!; //te wlasciwosci chce by byly*/
    }
}
