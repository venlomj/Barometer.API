using Barometer.BLL.Services.Interface;
using Barometer.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barometer.API.Controllers
{
    [Route("api/barometer")]
    [ApiController]
    public class BarometerController : ControllerBase
    {
        private readonly IBarometerService _barometerService;

        public BarometerController(IBarometerService barometerService)
        {
            _barometerService = barometerService;
        }

        [HttpGet("/get/all")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BarometerDto))]
        public async Task<IActionResult> GetAllBarometers()
        {
            return Ok(await _barometerService.GetAllBarometersAsync());
        }
        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetBarometerById(int id)
        {
            return Ok(await _barometerService.GetBarometerByIdAsync(id));
        }

        [HttpPost("/create")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBarometer([FromBody] BarometerRequest barometerRequest)
        {
            return Ok(await _barometerService.SaveBarometerAsync(barometerRequest));
        }
        [HttpPut("/update/{id}")]
        public async Task<IActionResult> UpdateBarometer(int id, [FromBody] BarometerRequest barometerRequest)
        {
            return Ok(await _barometerService.UpdateBarometerAsync(id, barometerRequest));
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteBarometec(int id)
        {
            return Ok(await _barometerService.DeleteBarometerAsync(id));
        }
    }
}
