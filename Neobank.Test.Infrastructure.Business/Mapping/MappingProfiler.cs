using AutoMapper;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Infrastructure.Business.DTO;

namespace Neobank.Test.Infrastructure.Business.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<FullFilmResponseDto, FullFilmModel> ();
            CreateMap<ShortFilmDto, ShortFilmModel>();
            CreateMap<FullFilmModel, WatchlistItemModel>()
                .AfterMap((src, dest) => dest.IsWatched = false).ReverseMap();
        }
    }
}
