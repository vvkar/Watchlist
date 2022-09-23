using AutoMapper;
using Neobank.Test.API.Models.Pesponses;
using Watchlist.Domain.Core.Models;

namespace Neobank.Test.API.Mapping
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
