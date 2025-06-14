using Microsoft.EntityFrameworkCore;
using RaceInfoApi.Core.Entities;
using RaceInfoApi.Infrastructure.Data;
using RaceInfoApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceInfoApi.Core.Dtos;

namespace RaceInfoApi.Infrastructure.Repositories
{

    public class RaceResultRepository : GenericRepository<RaceResult>, IRaceResultRepository
    {
        private readonly RaceDbContext _context;

        public RaceResultRepository(RaceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceResult>> GetAllWithDetailsAsync()
        {
            return await _context.RaceResults
                .Include(rr => rr.Driver)
                .Include(rr => rr.Race)
                .ToListAsync();
        }

        public async Task<IEnumerable<RaceResult>> GetFilteredAsync(RaceResultQueryParams queryParams)
        {
            var query = _context.RaceResults
                .Include(r => r.Race)
                .Include(r => r.Driver)
                .AsQueryable();

            if (queryParams.RaceId.HasValue)
                query = query.Where(r => r.RaceId == queryParams.RaceId);

            if (queryParams.DriverId.HasValue)
                query = query.Where(r => r.DriverId == queryParams.DriverId);

            if (queryParams.Position.HasValue)
                query = query.Where(r => r.Position == queryParams.Position);

            
            if (!string.IsNullOrEmpty(queryParams.SortBy))
            {
                switch (queryParams.SortBy.ToLower())
                {
                    case "position":
                        query = queryParams.SortOrder == "desc"
                            ? query.OrderByDescending(r => r.Position)
                            : query.OrderBy(r => r.Position);
                        break;
                    case "finishtime":
                        query = queryParams.SortOrder == "desc"
                            ? query.OrderByDescending(r => r.FinishTime)
                            : query.OrderBy(r => r.FinishTime);
                        break;
                    case "bestlaptime":
                        query = queryParams.SortOrder == "desc"
                            ? query.OrderByDescending(r => r.BestLapTime)
                            : query.OrderBy(r => r.BestLapTime);
                        break;
                    default:
                        query = query.OrderBy(r => r.id);
                        break;
                }
            }

            int skip = (queryParams.Page - 1) * queryParams.PageSize;
            return await query.Skip(skip).Take(queryParams.PageSize).ToListAsync();
        }
    }
}
