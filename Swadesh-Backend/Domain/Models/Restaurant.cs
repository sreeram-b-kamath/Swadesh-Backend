using System;
using System.Collections.Generic;
using Enums;

namespace Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string Address { get; set; }
    public UserRoles Roles { get; set; }
    public string Logo { get; set; }
    public string Background { get; set; }
    public string Cuisine { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string State { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public bool isEmailVerified { get; set; }
    public int OTP { get; set; }
    public bool OTPUsed { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime OtpExpiry { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
    public string UpdateEmail { get; set; }
    public bool InitialLogin { get; set; }
    public ICollection<RestaurantLang> RestaurantLang { get; set; }
    public ICollection<MenuCategory> MenuCategories { get; set; }
    public ICollection<MenuFilter> MenuFilters { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
    public ICollection<MenuCategoryLang> MenuCategoryLangs { get; set; }
    public ICollection<MenuFilterLang> MenuFiltersLangs { get; set; }
    public ICollection<MenuItemLang> MenuItemsLangs { get; set; }
    public ICollection<MenuItemRating> MenuItemRatings { get; set; }
}