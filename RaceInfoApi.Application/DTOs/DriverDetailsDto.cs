using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.DTOs
{
    public class DriverDetailsDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Team { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public List<DriverRaceResultDto> Results { get; set; } = new();
    }

    public class DriverRaceResultDto
    {
        public string RaceName { get; set; } = null!;
        public DateTime RaceDate { get; set; }
        public int Position { get; set; }
        public string Time { get; set; } = null!;
        public string BestLap { get; set; } = null!;
    }

}
