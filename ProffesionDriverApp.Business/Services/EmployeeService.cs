using AutoMapper;
using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.DataAccess.Repositories;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.Business.Services
{
    public class EmployeeService : TService<Employee, EmployeeViewModel, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository) : base(mapper, employeeRepository) { }
    }
}
