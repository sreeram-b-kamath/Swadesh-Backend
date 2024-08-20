using System;
using System.Collections.Generic;

namespace Models;

public class MenuItem
{
    public int Id { get; set; }
    public Guid uid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PrimaryImage { get; set; }
    public string[] Images { get; set; }
    public decimal Money { get; set; }
    public string Currency { get; set; }
    public int[] MenuFilterIds { get; set; }
    public bool InStock { get; set; }
    public int Order { get; set; }
    public bool Active { get; set; }
    public int Rating { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int MenuCategoryId { get; set; }
    public MenuCategory MenuCategory { get; set; }
    public ICollection<MenuItemLang> MenuItemslang { get; set; }
    public ICollection<MenuItemRating> MenuItemRatings { get; set; }
}