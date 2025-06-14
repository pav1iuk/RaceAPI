using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Application.Services
{
    using AutoMapper;
    using RaceInfoApi.Application.DTOs;
    using RaceInfoApi.Application.Services.Interfaces;
    using RaceInfoApi.Core.Entities;
    using RaceInfoApi.Infrastructure.Interfaces;

    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<Driver> _repo;
        private readonly IMapper _mapper;

        public DriverService(IGenericRepository<Driver> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverDto>> GetAllAsync()
        {
            var drivers = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }

        public async Task<DriverDto> GetByIdAsync(int id)
        {
            var driver = await _repo.GetByIdAsync(id);
            return _mapper.Map<DriverDto>(driver);
        }

        public async Task CreateAsync(DriverDto dto)
        {
            var driver = _mapper.Map<Driver>(dto);
            await _repo.AddAsync(driver);
        }

        public async Task UpdateAsync(DriverDto dto)
        {
            var driver = _mapper.Map<Driver>(dto);
            await _repo.UpdateAsync(driver);
        }

        public async Task DeleteAsync(int id)
        {
            var driver = await _repo.GetByIdAsync(id);
            if (driver != null)
                await _repo.DeleteAsync(driver);
        }
    }

}
