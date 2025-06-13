using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services.Interfaces;

namespace RaceInfoApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceResultsController : ControllerBase
    {
        private readonly IRaceResultService _service;

        public RaceResultsController(IRaceResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResultDto>>> GetAll()
        {
            var results = await _service.GetAllRaceResultsAsync();
            return Ok(results);
        }
    }
}
