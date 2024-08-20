using System;
using System.Collections.Generic;


namespace Models;

public class MenuCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public Guid Uid { get; set; }   
    public bool Active { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<MenuCategoryLang> MenuCategoryLanguage { get; set; }
}