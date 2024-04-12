using AutoMapper;
using Business.Generic;
using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business
{
    public class DriverManager : TManager<Driver, DriverViewModel, IDriverRepository>, IDriverManager
    {
        public DriverManager(IMapper mapper, IDriverRepository driverRepository) : base(mapper, driverRepository) { }
    }
}
