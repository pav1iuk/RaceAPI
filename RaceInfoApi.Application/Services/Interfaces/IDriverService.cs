using RaceInfoApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetAllAsync();
        Task<DriverDto> GetByIdAsync(int id);
        Task CreateAsync(DriverDto dto);
        Task UpdateAsync(DriverDto dto);
        Task DeleteAsync(int id);
    }
}
