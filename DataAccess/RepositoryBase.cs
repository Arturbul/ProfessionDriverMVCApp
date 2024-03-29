using Domain.Data;

namespace DataAccess
{
    public class RepositoryBase
    {
        private readonly ProfessionDriverProjectContext _context;
        public RepositoryBase(ProfessionDriverProjectContext context)
        {
            _context = context;
        }
        public ProfessionDriverProjectContext Context { get => _context; }
    }
}
