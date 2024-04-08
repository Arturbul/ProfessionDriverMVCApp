using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    internal class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(ProfessionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<IEnumerable<Employee>> Get()
        {
            var employee = await this.Context
                                    .Employees
                                    .AsNoTracking()
                                    .ToListAsync();

            return employee;
        }

        public async Task<Employee?> Get(int id)
        {
            var employee = await this.Context
                                    .Employees
                                    .Where(e => e.EmployeeId == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return employee;
        }

        //POST
        public async Task<int> Create(Employee employee)
        {
            using var context = this.Context;
            if (await check_relations(employee))
            {
                context.Employees.Add(employee);
            }

            await context.SaveChangesAsync();

            return employee.EmployeeId;
        }

        public async Task<int> Update(Employee employee)
        {
            using var context = this.Context;
            if (await check_relations(employee))
            {
                context.Employees.Update(employee);
            }

            await context.SaveChangesAsync();

            return employee.EmployeeId;
        }

        //DELETE
        public async Task<int> Delete(int employeeId)
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

        private async Task<bool> check_relations(Employee employee)
        {
            var result = await this.Context
                .Entities
                .FindAsync(employee.EntityId);
            return result != null ? true : false;
        }
    }
}
