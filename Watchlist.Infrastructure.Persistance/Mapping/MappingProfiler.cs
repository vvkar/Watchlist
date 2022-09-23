using AutoMapper;
using Watchlist.Domain.Core.Models;
using Watchlist.Infrastructure.Persistance.Entities;

namespace Watchlist.Infrastructure.Persistance.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<WatchlistItemEntity, WatchlistItemModel>().ReverseMap();
        }
    }
}
