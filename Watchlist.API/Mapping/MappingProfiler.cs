using AutoMapper;
using Watchlist.API.Models.Pesponses;
using Watchlist.Domain.Core.Models;

namespace Watchlist.API.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<ShortFilmModel, ShortFilmResponse>();
            CreateMap<WatchlistItemModel, WatchlistItemResponse>();
        }
    }
}
