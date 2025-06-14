﻿namespace RaceInfoApi.Mappings
{
    using AutoMapper;
    using RaceInfoApi.Application.DTOs;
    using RaceInfoApi.Core.Entities;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Race, RaceCreateDto>();
            CreateMap<RaceCreateDto, RaceDto>();
            CreateMap<RaceCreateDto, Race>()
    .ForMember(dest => dest.id, opt => opt.Ignore()) 
    .ForMember(dest => dest.Results, opt => opt.Ignore());


            CreateMap<Race, RaceDetailsDto>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            CreateMap<Driver, DriverDto>();

            CreateMap<Driver, DriverDetailsDto>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            CreateMap<RaceResult, RaceResultDto>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name))
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.Race.Name));

            CreateMap<RaceResult, DriverRaceResultDto>()
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.Race.Name))
                .ForMember(dest => dest.RaceDate, opt => opt.MapFrom(src => src.Race.Date));
            CreateMap<RaceResultDto, RaceResult>()
                .ForMember(dest => dest.Driver, opt => opt.Ignore())
                .ForMember(dest => dest.Race, opt => opt.Ignore());
            CreateMap<DriverDto, Driver>().ReverseMap();

            CreateMap<Race, RaceDto>();
            CreateMap<RaceDto, Race>();

            CreateMap<RaceResult, RaceResultDto>();
            CreateMap<Driver, DriverDto>();



        }
    }
}
