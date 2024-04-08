using AutoMapper;
using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.ViewModels;

namespace Business
{
    public class DriverManager : IDriverManager
    {
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;
        public DriverManager(IMapper mapper, IDriverRepository driverRepository)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        //GET
        public async Task<IEnumerable<DriverViewModel>> Get()
        {
            var drivers = await _driverRepository.Get();
            return _mapper.Map<IEnumerable<DriverViewModel>>(drivers);
        }

        public async Task<DriverViewModel?> Get(int id)
        {
            var driver = await _driverRepository.Get(id);
            return _mapper?.Map<DriverViewModel>(driver);
        }

        //POST
        public async Task<int> Create(DriverViewModel driverViewModel)
        {
            var driver = _mapper.Map<Driver>(driverViewModel);
            if (driver == null)
            {
                return 0;
            }
            return await _driverRepository.Create(driver);
        }
        public async Task<int> Update(DriverViewModel driverViewModel)
        {
            var driver = _mapper.Map<Driver>(driverViewModel);
            if (driver == null)
            {
                return 0;
            }
            return await _driverRepository.Update(driver);
        }

        //DELETE
        public async Task<int> Delete(int driverId)
        {
            return await _driverRepository.Delete(driverId);
        }
    }
}
