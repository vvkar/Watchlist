using AutoMapper;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Infrastructure.Persistance.Entities;

namespace Neobank.Test.Infrastructure.Persistance.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<WatchlistItemEntity, WatchlistItemModel>().ReverseMap();
        }
    }
}
