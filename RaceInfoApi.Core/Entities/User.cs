﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = "User";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
