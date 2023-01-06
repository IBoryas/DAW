using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Client;
using DAW.Common.DTOs.Deals;
using Microsoft.AspNetCore.Mvc;

namespace DAW.API.Controllers
{
    [Route("api/deals")]
    [ApiController]
    public class DealController:ControllerBase
    {
        private readonly IDealService _service;

        public DealController(IDealService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDealDto dealDto)
        {
            await _service.Add(dealDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deals = await _service.GetAll();
            return Ok(deals);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDealDto dealDto)
        {
            await _service.Update(id, dealDto);
            return Ok();
        }
    }
}
