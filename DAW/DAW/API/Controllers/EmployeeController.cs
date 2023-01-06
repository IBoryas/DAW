using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Employee;
using DAW.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAW.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.FindById(id);
            return Ok(employee);
        }

        [HttpGet("available")]
        [MyExceptionFilter]
        public async Task<IActionResult> GetAvailable()
        {
            var list = await _service.GetAvailable();
            return Ok(list);
        }

        [HttpGet("unavailable")]
        [MyExceptionFilter]
        public async Task<IActionResult> GetUnavailable()
        {
            var list = await _service.GetUnavailable();
            return Ok(list);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            await _service.UpdateEmployee(id,updateEmployeeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _service.DeleteEmployee(id);
            if (isDeleted)
                return Ok();
            else return BadRequest();
        }
    }
}
