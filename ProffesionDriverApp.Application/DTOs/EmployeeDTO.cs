namespace ProfessionDriverApp.Application.DTOs
{
    public class EmployeeDTO
    {
        public string? Name { get; set; }
        public AddressDTO? Address { get; set; }
        public AppUserDTO? AppUser { get; set; }
        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDriver { get; set; }
    }
}
