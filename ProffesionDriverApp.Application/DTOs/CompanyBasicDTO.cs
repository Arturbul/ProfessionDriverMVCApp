using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Application.DTOs
{
    public class CompanyBasicDTO
    {
        public string? Name { get; set; }
        public Address? Address { get; set; }
    }
}
