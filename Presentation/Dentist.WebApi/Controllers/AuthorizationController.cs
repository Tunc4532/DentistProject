using Dentist.Application.Features.Mediator.Queries.AuthorizationQueries;
using Dentist.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery command)
        {
            var values = await _mediator.Send(command);
            if (values.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(values));
            else return BadRequest("Kullanıcı adı veya şifre hatalı");
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser(RegisterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

    }
}
