using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.DTOs
{
    public class RaceDetailsDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Laps { get; set; }
        public double TrackLengthKm { get; set; }
        public string? Weather { get; set; }
        public List<RaceResultDto> Results { get; set; } = new();
    }

}
