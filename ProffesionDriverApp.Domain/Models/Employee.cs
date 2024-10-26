namespace ProfessionDriverApp.Domain.Models
{
    public class Employee : EntityBase
    {
        public int EmployeeId { get; set; }
        public int EntityId { get; set; }

        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public Individual Entity { get; set; } = null!;
        public override object Key => EmployeeId;
    }
}
