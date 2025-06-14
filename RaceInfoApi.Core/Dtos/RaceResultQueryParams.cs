using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Core.Dtos
{
    public class RaceResultQueryParams : RequestParams
    {
        public int? RaceId { get; set; }
        public int? DriverId { get; set; }
        public int? Position { get; set; }
    }
}
