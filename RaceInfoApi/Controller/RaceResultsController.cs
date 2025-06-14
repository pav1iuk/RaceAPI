using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services.Interfaces;
using RaceInfoApi.Core.Dtos;

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

        // 🔹 Отримати всі з деталями
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResultDto>>> GetAll()
        {
            var results = await _service.GetAllRaceResultsAsync();
            return Ok(results);
        }

        // 🔹 Фільтрація, сортування, пагінація
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<RaceResultDto>>> GetFiltered([FromQuery] RaceResultQueryParams queryParams)
        {
            var results = await _service.GetFilteredResultsAsync(queryParams);
            return Ok(results);
        }

        // 🔹 Отримати по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResultDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // 🔹 Створення нового запису
        [HttpPost]
        public async Task<ActionResult<RaceResultDto>> Create(RaceResultDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // 🔹 Оновлення запису
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RaceResultDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // 🔹 Видалення запису
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
   
