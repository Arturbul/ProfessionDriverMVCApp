namespace ProfessionDriverApp.Domain.Models
{
    public class Individual : EntityBase
    {
        public int IndividualId { get; set; }
        public string? IndividualName { get; set; }
        public override object Key => IndividualId;
    }
}
