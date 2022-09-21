using AutoMapper;
using Neobank.Test.API.Models.Pesponses;
using Neobank.Test.Domain.Core.DTO;

namespace Neobank.Test.API.Mapping
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<FilmDto, FilmResponse>();
        }
    }
}
