using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.DTOs
{
    public class TokenRequestDto
    {
        public string RefreshToken { get; set; } = null!;
    }
}
