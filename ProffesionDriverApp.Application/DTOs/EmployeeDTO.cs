namespace ProfessionDriverApp.Application.DTOs
{
    public class EmployeeDTO
    {
        public int IndividualId { get; set; }
        public string? IndividualName { get; set; }
        public override string ToString()
        {
            return $"IndividualId: {IndividualId}, Individual name: {IndividualName}";
        }
    }
}
