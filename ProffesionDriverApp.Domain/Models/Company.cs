using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Domain.Models
{
    public class Company : EntityBase, ICompanyScope
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

        public void AddEmployee(Employee employee)
        {
            if (employee.IsEmployed)
            {
                throw new InvalidOperationException("Employee is employed.");
            }

            employee.Company = this;

            if (employee.HireDate == null)
            {
                employee.HireDate = DateOnly.FromDateTime(DateTime.UtcNow);
            }
            employee.TerminationDate = null;

            if (employee.AppUser != null)
            {
                employee.AppUser.Company = this;
                employee.AppUser.Employee = employee;
            }

            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
            }
        }


        public void RemoveEmployee(Employee employee)
        {
            if (employee == null)
            {
                return;
            }
            if (employee.CompanyId != CompanyId)
            {
                throw new InvalidOperationException("Employee is not assigned to this company.");
            }

            if (employee.AppUser != null)
                employee.AppUser.CompanyId = null;
            if (employee.TerminationDate == null)
            {
                employee.TerminationDate = DateOnly.FromDateTime(DateTime.UtcNow);
            }
            //Employees.Remove(employee); // possible enumerator exceptions
        }
    }
}
