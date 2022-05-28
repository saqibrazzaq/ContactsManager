using Api.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos.User;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ApiControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService
                .RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
