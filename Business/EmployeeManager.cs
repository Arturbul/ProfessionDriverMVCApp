using AutoMapper;
using Business.Generic;
using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business
{
    public class EmployeeManager : TManager<Employee, EmployeeViewModel, IEmployeeRepository>, IEmployeeManager
    {
        public EmployeeManager(IMapper mapper, IEmployeeRepository employeeRepository) : base(mapper, employeeRepository) { }
    }
}
