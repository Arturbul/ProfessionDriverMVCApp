﻿using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DriverRepository : RepositoryBase, IDriverRepository
    {
        public DriverRepository(ProffesionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Driver>> GetDriver()
        {
            using var context = this.Context;
            var drivers = await context
                                .Drivers
                                .Include(e => e.Employee)
                                    .ThenInclude(en => en.Entity)
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(drivers);
        }

        public async Task<Driver?> GetDriver(int id)
        {
            using var context = this.Context;
            var drivers = await context
                                .Drivers
                                .Include(e => e.Employee)
                                    .ThenInclude(en => en.Entity)
                                .Where(d => d.DriverId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(drivers);
        }

        //POST
        public async Task<int> PostDriver(Driver driver)
        {
            using var context = this.Context;
            context.Drivers.Add(driver);
            await context.SaveChangesAsync();

            return driver.DriverId;
        }

        //DELETE
        public async Task<int> DeleteDriver(int driverId)
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
    }
}