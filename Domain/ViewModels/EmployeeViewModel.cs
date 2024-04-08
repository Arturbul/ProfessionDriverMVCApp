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
            return $"Entity name: {Entity!.EntityName}, EmployeeId: {EmployeeId}, EntityId: {EntityId}";
        }
    }
}
