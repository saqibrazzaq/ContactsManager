using Entities.Database;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPersonRepository
    {
        Task<Person?> GetPersonAsync(Guid personId, bool trackChanges);
        Task<PagedList<Person>> SearchPersonsAsync(PersonParameters personParameters, bool trackChanges);
        void CreatePerson(Person person);
        Task<IEnumerable<Person>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeletePerson(Person person);
    }
}
