using Entities.Database;
using Repository.Extensions.Utility;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class PersonRepositoryExtension
    {
        public static IQueryable<Person> Search (this IQueryable<Person> persons,
            PersonParameters personParameters)
        {
            // Empty search term
            if (string.IsNullOrWhiteSpace(personParameters.SearchTerm))
                return persons;

            // Convert to lower case
            var searchTerm = personParameters.SearchTerm.Trim().ToLower();

            // Search in different properties
            var personsToReturn = persons.Where(
                // Name
                x => (x.Name ?? "").ToLower().Contains(searchTerm) ||
                (x.Address1 ?? "").ToLower().Contains(searchTerm) ||
                (x.Address2 ?? "").ToLower().Contains(searchTerm)
                );

            return personsToReturn;
        }

        public static IQueryable<Person> Sort (this IQueryable<Person> persons,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return persons.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Person>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return persons.OrderBy(e => e.Name);

            return persons.OrderBy(orderQuery);
        }
    }
}
