using RaceInfoApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceInfoApi.Core.Dtos;

namespace RaceInfoApi.Application.Services.Interfaces
{
    public interface IRaceResultService
    {
        Task<IEnumerable<RaceResultDto>> GetAllAsync();
        Task<IEnumerable<RaceResultDto>> GetFilteredResultsAsync(RaceResultQueryParams queryParams);
        Task<RaceResultDto> GetByIdAsync(int id);
        Task<RaceResultDto> CreateAsync(RaceResultDto dto);
        Task<bool> UpdateAsync(int id, RaceResultDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RaceResultDto>> GetAllRaceResultsAsync();
    }
}
