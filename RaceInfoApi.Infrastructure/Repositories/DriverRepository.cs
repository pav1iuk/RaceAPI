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
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private readonly RaceDbContext _context;

        public DriverRepository(RaceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Driver?> GetDriverDetailsAsync(int id)
        {
            return await _context.Drivers
                .Include(d => d.Results)
                    .ThenInclude(r => r.Race)
                .FirstOrDefaultAsync(d => d.id == id);
        }
    }

}
