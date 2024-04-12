namespace Domain.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public int EntityId { get; set; }
        public EntityViewModel? Entity { get; set; }

        public override string ToString()
        {
            return $"EmployeeId: {EmployeeId}, HireDate: {HireDate}, TerminationDate: {TerminationDate}, EntityId: {EntityId},\n Entity: {Entity}";
        }
    }
}
