using AutoMapper;
using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        //GET
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            var employees = await _employeeRepository.Get();
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        }

        public async Task<EmployeeViewModel?> Get(int id)
        {
            var employee = await _employeeRepository.Get(id);
            if (employee == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeViewModel>(employee);
        }

        //POST
        public async Task<int> Create(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);
            if (employee == null)
            {
                return 0;
            }
            return await _employeeRepository.Create(employee);
        }
        public async Task<int> Update(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);
            if (employee == null)
            {
                return 0;
            }
            return await _employeeRepository.Update(employee);
        }

        //DELETE
        public async Task<int> Delete(int employeeId)
        {
            return await _employeeRepository.Delete(employeeId);
        }
    }
}
