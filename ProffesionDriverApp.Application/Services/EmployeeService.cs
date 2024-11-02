using AutoMapper;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<int>> Get()
        {
            _unitOfWork.Repository<Employee>().Add(new Employee());
            return null;
        }
    }
}
