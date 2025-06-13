namespace RaceInfoApi.Mappings
{
    using AutoMapper;
    using RaceInfoApi.Application.DTOs;
    using RaceInfoApi.Core.Entities;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Race, RaceDto>();

            CreateMap<Race, RaceDetailsDto>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            CreateMap<RaceResult, RaceResultDto>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name));
            CreateMap<Driver, DriverDto>();

            CreateMap<Driver, DriverDetailsDto>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            CreateMap<RaceResult, DriverRaceResultDto>()
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.Race.Name))
                .ForMember(dest => dest.RaceDate, opt => opt.MapFrom(src => src.Race.Date));

            CreateMap<RaceResult, RaceResultDto>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name))
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.Race.Name));

        }
    }
}
