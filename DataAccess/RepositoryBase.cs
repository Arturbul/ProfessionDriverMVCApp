using Domain.Data;

namespace DataAccess
{
    public class RepositoryBase
    {
        private readonly ProffesionDriverProjectContext _context;
        public RepositoryBase(ProffesionDriverProjectContext context)
        {
            _context = context;
        }
        public ProffesionDriverProjectContext Context { get => _context; }
    }
}
