using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    internal class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(ProffesionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Employee>> GetEmployee()
        {
            return await Task.FromResult(this.Context.Employees.ToList());
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            using var context = this.Context;
            var employee = await context
                                    .Employees
                                    .Where(e => e.EmployeeId == id)
                                    .FirstOrDefaultAsync();

            return await Task.FromResult(employee);
        }

        //POST
        public async Task<int> PostEmployee(Employee employee)
        {
            using var context = this.Context;
            context.Employees.Add(employee);

            await context.SaveChangesAsync();

            return employee.EmployeeId;
        }

        //DELETE
        public async Task<int> DeleteEmployee(int employeeId)
        {
            using var context = this.Context;
            var employee = await context
                                .Employees
                                .FindAsync(employeeId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return employee.EmployeeId;
            }
            return 0;
        }
    }
}
