using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Application.Requests.Create
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; } = null!;
        public Address? Address { get; set; }
        public string ManagerLogin { get; set; } = null!;
    }
}
