using ClincProject.Api.Bases;
using ClincProject.Core.Features.Patients.Commands.Models;
using ClincProject.Core.Features.Patients.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClincProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : AppControllerBase
    {





        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetPatientsList()
        {
            var response = await Mediator.Send(new GetPatientsListQuery());
            return NewResult(response);
        }


        [HttpGet]
        [Route("Paginated/List")]
        public async Task<IActionResult> GetPatientsPaginatedList([FromQuery] GetPatientsPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetPatientByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatient([FromBody] AddPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePatient([FromBody] EditPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            var respoonse = await Mediator.Send(new DeletePatientCommand(Id));
            return NewResult(respoonse);
        }
    }
}
