using AutoMapper;
using Models;
using Dtos;
using Shared;
using Application.Dto_s;

namespace Swadesh_Backend
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<MenuItem, PostToMenuDto>().ReverseMap();
        }
    }
}
