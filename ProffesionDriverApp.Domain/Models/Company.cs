using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Domain.Models
{
    public class Company : EntityBase
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public Address? Address { get; set; }

        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public IList<Driver> Drivers { get; set; } = new List<Driver>();
        public IList<LargeGoodsVehicle> Vehicles { get; set; } = new List<LargeGoodsVehicle>();
        public IList<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();
        public IList<VehicleInspection> VehicleInspections { get; set; } = new List<VehicleInspection>();

        public override object Key => CompanyId;


    }
}
