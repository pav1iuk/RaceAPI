using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.DTOs
{
    public class RaceResultDto
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int Position { get; set; }
        public string? FinishTime { get; set; }
        public string? BestLapTime { get; set; }

        public string? DriverName { get; set; }
        public string? RaceName { get; set; }
        public DriverDto Driver { get; set; }
    }
}
