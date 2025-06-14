using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Weather { get; set; }
        public double TrackLength { get; set; }
        public int Laps { get; set; }

        public ICollection<Result> Results { get; set; }
    }

}
