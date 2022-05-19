using AutoMapper;
using Entities.Database;
using Shared.Dtos.PersonDtos;
using Shared.Dtos.User;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Person
            CreateMap<Person, PersonDto>();
            CreateMap<PersonForCreationDto, Person>();
            CreateMap<PersonForUpdateDto, Person>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
