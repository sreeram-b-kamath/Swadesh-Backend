using System;
using System.Collections.Generic;
using Enums;
using Microsoft.AspNetCore.Identity;

namespace Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }
    public string Cuisine { get; set; }
    public string Contact { get; set; }
    public bool Active { get; set; }
    public bool InitialLogin { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<RestaurantLang> RestaurantLang { get; set; }
    public ICollection<MenuCategory> MenuCategories { get; set; }
    public ICollection<MenuFilter> MenuFilters { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
    public ICollection<MenuCategoryLang> MenuCategoryLangs { get; set; }
    public ICollection<MenuFilterLang> MenuFiltersLangs { get; set; }
    public ICollection<MenuItemLang> MenuItemsLangs { get; set; }
    public ICollection<MenuItemRating> MenuItemRatings { get; set; }
}