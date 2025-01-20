using EmpMgmt.Core.Features.AddOrUpdateEmployeeFeature;
using EmpMgmt.Core.Features.DeleteEmployee;
using EmpMgmt.Core.Features.GetEmployeeData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addOrUpdateEmployee")]
        public async Task<IActionResult> AddOrUpdateEmployee(AddOrUpdateEmployeeModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPost("getEmployees")]
        public async Task<IActionResult> GetEmployees(
            [FromBody] GetEmployeesModel model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete("deleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(
            [FromRoute] DeleteEmployeeModel model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
