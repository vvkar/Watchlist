using AutoMapper;
using Neobank.Test.API.Models.Pesponses;
using Neobank.Test.Domain.Core.Models;

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
