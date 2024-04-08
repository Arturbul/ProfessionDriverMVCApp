using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DriverRepository : RepositoryBase, IDriverRepository
    {
        public DriverRepository(ProfessionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Driver>> Get()
        {
            var drivers = await this.Context
                                .Drivers
                                .OrderBy(e => e.DriverId)
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(drivers);
        }

        public async Task<Driver?> Get(int id)
        {
            var drivers = await this.Context
                                .Drivers
                                .Where(d => d.DriverId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(drivers);
        }

        //POST
        public async Task<int> Create(Driver driver)
        {
            using var context = this.Context;
            if (await check_relations(driver))
            {
                context.Drivers.Add(driver);
            }
            await context.SaveChangesAsync();

            return driver.DriverId;
        }
        public async Task<int> Update(Driver driver)
        {
            using var context = this.Context;
            if (await check_relations(driver))
            {
                context.Drivers.Update(driver);
            }
            await context.SaveChangesAsync();

            return driver.DriverId;
        }

        //DELETE
        public async Task<int> Delete(int driverId)
        {
            using var context = this.Context;
            var driver = await context
                                .Drivers
                                .FindAsync(driverId);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                await context.SaveChangesAsync();

                return driver.DriverId;
            }
            return 0;
        }

        private async Task<bool> check_relations(Driver driver)
        {
            var result = await this.Context
                .Employees
                .FindAsync(driver.EmployeeId);
            return result != null ? true : false;
        }
    }
}
