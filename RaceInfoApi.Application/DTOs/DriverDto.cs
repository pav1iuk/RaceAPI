using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.DTOs
{
    public class DriverDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Team { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }

}
