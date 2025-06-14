using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Core.Entities
{
    public class Race
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Location { get; set; } = null!;
        public int Laps { get; set; }
        public double TrackLengthKm { get; set; }
        public string Weather { get; set; } = null!;

        public ICollection<RaceResult> Results { get; set; } = new List<RaceResult>();
    }
}
