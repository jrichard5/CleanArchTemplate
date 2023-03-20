using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
