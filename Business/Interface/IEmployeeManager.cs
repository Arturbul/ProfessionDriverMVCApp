using Business.Generic.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business.Interface
{
    public interface IEmployeeManager : ITManager<Employee, EmployeeViewModel>
    {
    }
}
