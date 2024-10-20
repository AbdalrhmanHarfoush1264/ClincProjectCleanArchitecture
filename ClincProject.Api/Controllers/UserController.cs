using ClincProject.Api.Bases;
using ClincProject.Core.Features.Users.Commands.Models;
using ClincProject.Core.Features.Users.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClincProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet("Paginated/List")]
        public async Task<IActionResult> GetUserPaginatedList([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(Id));
            return NewResult(response);
        }

        [HttpPut("Change Password")]
        public async Task<IActionResult> ChangePasswordForUser([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
