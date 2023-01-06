using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Client;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DAW.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateClientDto clientDto)
        {
            await _service.Add(clientDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAll();
            return Ok(clients);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClientDto clientDto)
        {
            await _service.Update(id, clientDto);
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var clients = await _service.GetList();
            return Ok(clients);
        }
    }
}
