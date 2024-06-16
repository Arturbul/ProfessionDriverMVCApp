using AutoMapper;
using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.DataAccess.Repositories;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.Business.Services
{
    public class DriverService : TService<Driver, DriverViewModel, IDriverRepository>, IDriverService
    {
        public DriverService(IMapper mapper, IDriverRepository driverRepository) : base(mapper, driverRepository) { }
    }
}
