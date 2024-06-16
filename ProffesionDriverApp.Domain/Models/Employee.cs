using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionDriverApp.Domain.Models
{
    public class Employee
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public int EntityId { get; set; }

        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public Entity Entity { get; set; } = null!;
    }
}
