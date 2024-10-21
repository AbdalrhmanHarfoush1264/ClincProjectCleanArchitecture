using ClincProject.Api.Bases;
using ClincProject.Core.Features.Authorizations.Commands.Models;
using ClincProject.Core.Features.Authorizations.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClincProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorzationController : AppControllerBase
    {
        [HttpGet("List")]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRoleListQuery());
            return NewResult(response);
        }

        [HttpGet("Role/{Id:int}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(Id));
            return NewResult(response);
        }

        [HttpGet("Manager-User-Roles/{UserId:int}")]
        public async Task<IActionResult> ManagerUserRoles([FromRoute] int UserId)
        {
            var response = await Mediator.Send(new ManagerUserRolesQuery(UserId));
            return NewResult(response);
        }


        [HttpPut("Update-User-Roles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] EditUserRolesCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
