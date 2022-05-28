using Api.ActionFilters;
using Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos.PersonDtos;
using Shared.RequestFeatures;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        private readonly IServiceManager _service;

        public PersonsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> CreatePerson(
            [FromBody]PersonForCreationDto personDto)
        {
            var response = await _service.PersonService.CreatePersonAsync(personDto);
            if (!response.Success)
                return ProcessError(response);
            var result = response.GetResult<PersonDto>();
            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "GetPerson")]
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var response = await _service.PersonService.GetPersonAsync(
                id, trackChanges: false);
            if (!response.Success)
                return ProcessError(response);
            var result = response.GetResult<PersonDto>();
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Manager,Administrator")]
        [ServiceFilter(typeof (ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePerson (Guid id, 
            [FromBody] PersonForUpdateDto person)
        {
            await _service.PersonService.UpdatePersonAsync(id, person,
                trackChanges: true);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<IActionResult> SearchPersons (
            [FromQuery] PersonParameters personParameters)
        {
            var response = await _service.PersonService.SearchPersonsAsync(
                personParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(
                response.MetaData));
            if (!response.Success)
                return ProcessError(response);
            return Ok(response.PagedList);
        }
    }
}
