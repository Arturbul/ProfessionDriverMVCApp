using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class Driver
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;
        public ICollection<DriverWorkLog>? DriverWorkLogs { get; set; }
    }
}
