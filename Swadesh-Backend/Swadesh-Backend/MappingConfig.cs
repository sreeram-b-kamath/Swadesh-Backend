using AutoMapper;
using Models;
using Dtos;
using Shared;

namespace Swadesh_Backend
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Restaurant, RestuarantUserGetDto>().ReverseMap();
        }
    }
}
