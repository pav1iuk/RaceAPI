using RaceInfoApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Interfaces
{
    public interface IRaceRepository : IRepository<Race>
    {
        Task<IEnumerable<Race>> GetUpcomingRacesAsync();
        Task<IEnumerable<Race>> GetPastRacesAsync();
        Task<Race?> GetRaceDetailsAsync(int id);
    }
}
