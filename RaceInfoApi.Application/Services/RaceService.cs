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

    public class RaceService : IRaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RaceDto>> GetAllAsync()
        {
            var races = await _unitOfWork.Races.GetAllAsync();
            return _mapper.Map<IEnumerable<RaceDto>>(races);
        }

        public async Task<RaceDto> GetByIdAsync(int id)
        {
            var race = await _unitOfWork.Races.GetByIdAsync(id);
            return _mapper.Map<RaceDto>(race);
        }

        public async Task<RaceDto?> GetRaceDetailsAsync(int id)
        {
            var race = await _unitOfWork.Races.GetRaceDetailsAsync(id);
            return _mapper.Map<RaceDto>(race);
        }

        public async Task<IEnumerable<RaceDto>> GetUpcomingAsync()
        {
            var upcoming = await _unitOfWork.Races.GetUpcomingRacesAsync();
            return _mapper.Map<IEnumerable<RaceDto>>(upcoming);
        }

        public async Task<IEnumerable<RaceDto>> GetPastAsync()
        {
            var past = await _unitOfWork.Races.GetPastRacesAsync();
            return _mapper.Map<IEnumerable<RaceDto>>(past);
        }

        public async Task CreateAsync(RaceDto dto)
        {
            var race = _mapper.Map<Race>(dto);
            await _unitOfWork.Races.AddAsync(race);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(RaceDto dto)
        {
            var race = _mapper.Map<Race>(dto);
            await _unitOfWork.Races.UpdateAsync(race);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var race = await _unitOfWork.Races.GetByIdAsync(id);
            if (race != null)
            {
                await _unitOfWork.Races.DeleteAsync(race);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
