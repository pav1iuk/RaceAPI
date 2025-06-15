using RaceInfoApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.Services.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<RaceDto>> GetAllAsync();
        Task<RaceDto> GetByIdAsync(int id);
        Task<RaceDto?> GetRaceDetailsAsync(int id);
        Task<IEnumerable<RaceDto>> GetUpcomingAsync();
        Task<IEnumerable<RaceDto>> GetPastAsync();
        Task<RaceDto> CreateAsync(RaceDto dto);
        Task UpdateAsync(RaceDto dto);
        Task DeleteAsync(int id);
    }
}
