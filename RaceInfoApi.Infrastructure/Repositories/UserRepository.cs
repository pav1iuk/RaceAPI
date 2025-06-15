using Microsoft.EntityFrameworkCore;
using RaceInfoApi.Core.Entities;
using RaceInfoApi.Infrastructure.Data;
using RaceInfoApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RaceDbContext _context;

        public UserRepository(RaceDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
