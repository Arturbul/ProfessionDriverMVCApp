namespace ProfessionDriverApp.Domain.Models
{
    public class Driver : EntityBase
    {
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;
        public IList<DriverWorkLog>? DriverWorkLogs { get; set; }
        public override object Key => DriverId;
    }
}
