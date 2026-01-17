using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCrud.Collage.Dto;

namespace UserCrud.Collage
{
    public class CollageAutoMapperProfile : Profile
    {
        public CollageAutoMapperProfile()
        {
            CreateMap<Collage, CollageDto>();
            CreateMap<CreatecollageDto, Collage>();
            CreateMap<UpdateCollageDto, Collage>();
        }
    }
}
