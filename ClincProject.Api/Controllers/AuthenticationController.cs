using ClincProject.Api.Bases;
using ClincProject.Core.Features.Authentications.Commands.Models;
using ClincProject.Core.Features.Authentications.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClincProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {

        [HttpPost("Sign-In")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("Refresh-Token")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("Is-Valid_Token")]
        public async Task<IActionResult> IsValidToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

    }
}
