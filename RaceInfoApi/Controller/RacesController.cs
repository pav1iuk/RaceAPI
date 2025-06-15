using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services;
using RaceInfoApi.Application.Services.Interfaces;
using RaceInfoApi.Core.Entities;
using RaceInfoApi.Infrastructure.Interfaces;

namespace RaceInfoApi.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceService _service;
        private readonly IMapper _mapper;
        public RacesController(IRaceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RaceCreateDto dto)
        {
            var raceDto = _mapper.Map<RaceDto>(dto);
            await _service.CreateAsync(raceDto);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RaceDto dto)
        {
            dto.id = id;
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetRaceDetails(int id)
        {
            var race = await _service.GetRaceDetailsAsync(id);
            return race == null ? NotFound() : Ok(race);
        }

    }

}
