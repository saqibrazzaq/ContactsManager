using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        // List all repositories
        private readonly Lazy<IPersonRepository> _personRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _personRepository = new Lazy<IPersonRepository>(() =>
                new PersonRepository(context));
        }

        public IPersonRepository PersonRepository => _personRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
