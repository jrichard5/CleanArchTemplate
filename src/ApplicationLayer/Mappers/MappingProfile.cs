using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using AutoMapper;

namespace ApplicationLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cat, CatDTO>();
            CreateMap<Cat, CreateCatDto>();
            CreateMap<CreateCatDto, Cat>();
        }
    }
}
