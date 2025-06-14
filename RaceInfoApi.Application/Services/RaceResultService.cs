using AutoMapper;
using RaceInfoApi.Application.DTOs;
using RaceInfoApi.Application.Services.Interfaces;
using RaceInfoApi.Core.Entities;
using RaceInfoApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceInfoApi.Core.Dtos;

namespace RaceInfoApi.Application.Services
{
    public class RaceResultService : IRaceResultService
    {
        private readonly IRaceResultRepository _repository;
        private readonly IMapper _mapper;

        public RaceResultService(IRaceResultRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RaceResultDto>> GetAllAsync()
        {
            var results = await _repository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<RaceResultDto>>(results);
        }

        public async Task<IEnumerable<RaceResultDto>> GetFilteredResultsAsync(RaceResultQueryParams queryParams)
        {
            var filtered = await _repository.GetFilteredAsync(queryParams);
            return _mapper.Map<IEnumerable<RaceResultDto>>(filtered);
        }
        public async Task<IEnumerable<RaceResultDto>> GetAllRaceResultsAsync()
        {
            var results = await _repository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<RaceResultDto>>(results);
        }


        public async Task<RaceResultDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<RaceResultDto>(result);
        }

        public async Task<RaceResultDto> CreateAsync(RaceResultDto dto)
        {
            var entity = _mapper.Map<RaceResult>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<RaceResultDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, RaceResultDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return false;

            await _repository.DeleteAsync(result);
            return true;
        }
    }
}
