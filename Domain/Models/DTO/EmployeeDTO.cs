namespace Domain.Models.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int EntityId { get; set; }

        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
    }
}
