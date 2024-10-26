using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Domain.Models
{
    public class Individual : EntityBase
    {
        public int IndividualId { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public override object Key => IndividualId;
    }
}
