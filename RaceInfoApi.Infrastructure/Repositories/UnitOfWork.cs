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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RaceDbContext _context;

        public IRaceRepository Races { get; private set; }
        public IDriverRepository Drivers { get; private set; }
        public IRepository<RaceResult> RaceResults { get; private set; }

        public UnitOfWork(RaceDbContext context)
        {
            _context = context;
            Races = new RaceRepository(context);
            Drivers = new DriverRepository(context);
            RaceResults = new Repository<RaceResult>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
