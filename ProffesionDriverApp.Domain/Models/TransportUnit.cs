using ProfessionDriverApp.Domain.Interfaces;

namespace ProfessionDriverApp.Domain.Models
{
    public class TransportUnit : EntityBase, ICompanyScope
    {
        public int TransportUnitId { get; set; }
        public string? Brand { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string? TrailerBrand { get; set; }
        public string? RegistrationNumberTrailer { get; set; }
        public IList<DriverWorkLog>? DriverWorkLogs { get; set; }
        public override object Key => TransportUnitId;
        public int CompanyId { get; set; }
    }
}
