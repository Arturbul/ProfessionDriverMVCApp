using AutoMapper;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Application.Services
{
    internal class IndividualService : IIndividualService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndividualService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<int>> Get()
        {
            return null;
        }
    }
}
