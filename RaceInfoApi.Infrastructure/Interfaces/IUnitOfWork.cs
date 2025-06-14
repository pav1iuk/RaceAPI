using RaceInfoApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRaceRepository Races { get; }
        IDriverRepository Drivers { get; }
        IRepository<RaceResult> RaceResults { get; }
        Task<int> CompleteAsync();
    }
}
