using Entities.Database;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreatePerson(Person person)
        {
            Create(person);
        }

        public void DeletePerson(Person person)
        {
            Delete(person);
        }

        public async Task<IEnumerable<Person>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();
        }

        public async Task<Person?> GetPersonAsync(Guid personId, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(personId), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<Person>> SearchPersonsAsync(
            PersonParameters personParameters, bool trackChanges)
        {
            // Find persons
            var persons = await FindAll(trackChanges)
                .Search(personParameters)
                .Sort(personParameters.OrderBy)
                .Skip((personParameters.PageNumber - 1) * personParameters.PageSize)
                .Take(personParameters.PageSize)
                .ToListAsync();
            // Get count by using the same search parameters
            var count = await FindAll(trackChanges)
                .Search(personParameters)
                .CountAsync();
            return new PagedList<Person>(persons, count, personParameters.PageNumber,
                personParameters.PageSize);
        }
    }
}
