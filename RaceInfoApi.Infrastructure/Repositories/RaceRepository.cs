using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RaceInfoApi.Core.Entities;
    using RaceInfoApi.Infrastructure.Data;
    using RaceInfoApi.Infrastructure.Interfaces;

    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(RaceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Race>> GetUpcomingRacesAsync()
        {
            return await _context.Races
                .Where(r => r.Date > DateTime.UtcNow)
                .OrderBy(r => r.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetPastRacesAsync()
        {
            return await _context.Races
                .Where(r => r.Date <= DateTime.UtcNow)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public async Task<Race?> GetRaceDetailsAsync(int id)
        {
            return await _context.Races
                .Include(r => r.Results)
                    .ThenInclude(rr => rr.Driver)
                .FirstOrDefaultAsync(r => r.id == id);
        }
    }
}
