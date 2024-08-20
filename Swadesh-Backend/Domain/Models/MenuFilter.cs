using System.Collections.Generic;

namespace Models;


public class MenuFilter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public string Icon { get; set; }
    public bool Active { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<MenuFilterLang> MenuFilterlang { get; set; }
}