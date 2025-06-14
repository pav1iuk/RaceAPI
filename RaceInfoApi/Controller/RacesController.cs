using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services;
using RaceInfoApi.Application.Services.Interfaces;
using RaceInfoApi.Infrastructure.Interfaces;

namespace RaceInfoApi.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceService _service;

        public RacesController(IRaceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RaceDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RaceDto dto)
        {
            dto.id = id;
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetRaceDetails(int id)
        {
            var race = await _service.GetRaceDetailsAsync(id);
            return race == null ? NotFound() : Ok(race);
        }

    }

}
