using Microsoft.AspNetCore.Mvc;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services.Interfaces;

namespace RaceInfoApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetAll()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDetailsDto>> GetById(int id)
        {
            var driver = await _driverService.GetDriverDetailsAsync(id);
            if (driver == null)
                return NotFound();

            return Ok(driver);
        }
    }


}
