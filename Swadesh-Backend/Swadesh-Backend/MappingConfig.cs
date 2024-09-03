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
            CreateMap<Restaurant, RestaurantGetDto>().ReverseMap();
            CreateMap<Restaurant, RestuarantUserGetDto>().ReverseMap();
            CreateMap<MenuItem, PostToMenuDto>().ReverseMap();
        }
    }
}
