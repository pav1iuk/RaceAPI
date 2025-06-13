using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.Services.Interfaces;
using RaceInfoApi.Infrastructure.Interfaces;

namespace RaceInfoApi.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRaceService _raceService;
        public RacesController(IUnitOfWork unitOfWork, IRaceService raceService)
        {
            _unitOfWork = unitOfWork;
            _raceService = raceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var races = await _unitOfWork.Races.GetAllAsync();
            return Ok(races);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var race = await _unitOfWork.Races.GetByIdAsync(id);
            if (race == null)
                return NotFound();

            return Ok(race);
        }
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming()
        {
            var races = await _raceService.GetUpcomingRacesAsync();
            return Ok(races);
        }

        [HttpGet("past")]
        public async Task<IActionResult> GetPast()
        {
            var races = await _raceService.GetPastRacesAsync();
            return Ok(races);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var race = await _raceService.GetRaceDetailsAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }
    }

}
