using RaceInfoApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceInfoApi.Core.Dtos;

namespace RaceInfoApi.Infrastructure.Interfaces
{
    public interface IRaceResultRepository : IGenericRepository<RaceResult>
    {
        Task<IEnumerable<RaceResult>> GetAllWithDetailsAsync();
        Task<IEnumerable<RaceResult>> GetFilteredAsync(RaceResultQueryParams queryParams);
    }
}
