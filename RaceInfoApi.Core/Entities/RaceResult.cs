using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Core.Entities
{
    public class RaceResult
    {
        public int id { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; } = null!;

        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;

        public int Position { get; set; }
        public TimeSpan FinishTime { get; set; }
        public TimeSpan BestLapTime { get; set; }
    }
}
