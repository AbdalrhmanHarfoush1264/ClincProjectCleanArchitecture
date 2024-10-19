using ClincProject.Api.Bases;
using ClincProject.Core.Features.Users.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClincProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {

        [HttpPost("Create")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
