namespace ProfessionDriverApp.Domain.ViewModels
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel? Employee { get; set; }
        //driver work log collection
    }
}
