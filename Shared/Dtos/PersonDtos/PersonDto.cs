using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.PersonDtos
{
    public record PersonDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Address1 { get; init; }
        public string? Address2 { get; init; }
    }
}
