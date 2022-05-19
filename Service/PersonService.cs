using AutoMapper;
using Contracts;
using Entities.Database;
using Entities.Exceptions;
using Entities.Responses;
using Repository.Contracts;
using Service.Contracts;
using Shared.Dtos.PersonDtos;
using Shared.RequestFeatures;

namespace Service
{
    public sealed class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repository, 
            ILoggerManager logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApiOkResponse<PersonDto>> CreatePersonAsync(PersonForCreationDto personForCreation)
        {
            var personEntity = _mapper.Map<Person>(personForCreation);
            _repository.PersonRepository.CreatePerson(personEntity);
            await _repository.SaveAsync();

            var personToReturn = _mapper.Map<PersonDto>(personEntity);
            return new ApiOkResponse<PersonDto>(personToReturn);
        }

        public Task<ApiBaseResponse> DeletePersonAsync(Guid personId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiOkResponse<PersonDto>> GetPersonAsync(Guid personId, bool trackChanges)
        {
            var personEntity = await GetPersonAndCheckIfExists(personId, trackChanges);
            var personToReturn = _mapper.Map<PersonDto>(personEntity);
            return new ApiOkResponse<PersonDto>(personToReturn);
        }

        public async Task<ApiOkPagedResponse<IEnumerable<PersonDto>, MetaData>> 
            SearchPersonsAsync(PersonParameters personParameters, bool trackChanges)
        {
            var personsWithMetadata = await _repository.PersonRepository.SearchPersonsAsync(
                personParameters, trackChanges);
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(personsWithMetadata);
            return new ApiOkPagedResponse<IEnumerable<PersonDto>, MetaData>(
                personsDto, personsWithMetadata.MetaData);
        }

        public async Task UpdatePersonAsync(Guid personId, 
            PersonForUpdateDto personDto, bool trackChanges)
        {
            var personEntity = await GetPersonAndCheckIfExists(personId, trackChanges);
            // Track changes are ON, just convert to dto and save
            _mapper.Map(personDto, personEntity);
            await _repository.SaveAsync();
        }

        private async Task<Person> GetPersonAndCheckIfExists(Guid id, bool trackChanges)
        {
            var personEntity = await _repository.PersonRepository.GetPersonAsync(
                id, trackChanges);
            if (personEntity == null)
                throw new NotFoundException($"{id}: Person not found.");
            return personEntity;
        }
    }
}