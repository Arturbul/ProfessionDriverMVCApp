using AutoMapper;
using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.DataAccess.Repositories;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.Business.Services
{
    public class DriverWorkLogService : TService<DriverWorkLog, DriverWorkLogViewModel, IDriverWorkLogRepository>, IDriverWorkLogService
    {
        public DriverWorkLogService(IMapper mapper, IDriverWorkLogRepository workLogRepository) : base(mapper, workLogRepository) { }
    }
}
