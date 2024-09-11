﻿using AutoMapper;
using Models;
using Dtos;
using Shared;
using Application.Dto_s;
using Domain.Models;

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
            CreateMap<MenuCategory, CategoryMenuItemsResponseDto>();
            CreateMap<MenuItem, GetMenuItemDto>()
                .ForMember(dest => dest.IngredientIds, opt => opt.MapFrom(src => src.MenuItemIngredients.Select(mi => mi.IngredientId).ToArray()));
            CreateMap<Ingredients, GetingredientsDto>().ReverseMap();
        }
    }
}
