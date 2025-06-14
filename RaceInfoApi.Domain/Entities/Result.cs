using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Domain.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string Driver { get; set; }
        public TimeSpan Time { get; set; }
        public string BestLap { get; set; }
        public int Position { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }
    }

}
