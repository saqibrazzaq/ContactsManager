using Entities.Responses;
using Shared.Dtos.PersonDtos;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPersonService
    {
        Task<ApiOkResponse<PersonDto>> GetPersonAsync(Guid personId, bool trackChanges);
        Task<ApiOkPagedResponse<IEnumerable<PersonDto>, MetaData>> SearchPersonsAsync(PersonParameters personParameters, bool trackChanges);
        Task<ApiOkResponse<PersonDto>> CreatePersonAsync (PersonForCreationDto personForCreation);
        Task<ApiBaseResponse> DeletePersonAsync(Guid personId, bool trackChanges);
        Task UpdatePersonAsync (Guid personId, 
            PersonForUpdateDto personForUpdate, bool trackChanges);
    }
}