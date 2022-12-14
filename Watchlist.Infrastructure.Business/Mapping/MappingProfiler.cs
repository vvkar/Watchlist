using AutoMapper;
using Watchlist.Domain.Core.Models;
using Watchlist.Infrastructure.Business.DTO;

namespace Watchlist.Infrastructure.Business.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<FullFilmResponseDto, FullFilmModel>();
            CreateMap<ShortFilmDto, ShortFilmModel>();
            CreateMap<FullFilmModel, WatchlistItemModel>().ReverseMap();
            CreateMap<PosterDto, PosterModel>();
            CreateMap<WikiDto, WikiModel>();
        }
    }
}
