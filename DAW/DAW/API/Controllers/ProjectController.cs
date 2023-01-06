using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Deals;
using DAW.Common.DTOs.Project;
using Microsoft.AspNetCore.Mvc;

namespace DAW.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var projects = await _service.GetList();
            return Ok(projects);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var projects = await _service.GetAvailable();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProjectDto projectDto)
        {
            await _service.Add(projectDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _service.GetAll();
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectDto projectDto)
        {
            await _service.Update(id, projectDto);
            return Ok();
        }
    }
}
