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
            CreateMap<Restaurant, RestuarantUserGetDto>().ReverseMap();
            CreateMap<MenuItem, PostToMenuDto>().ReverseMap();

            CreateMap<MenuItem, MenuItemResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.MenuCategory.Name));

            // Map Category to CategoryMenuItemsResponse
            CreateMap<MenuCategory, CategoryMenuItemsResponseDto>();
        }
    }
}
