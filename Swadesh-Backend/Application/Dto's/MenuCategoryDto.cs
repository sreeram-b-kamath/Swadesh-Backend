using System;
using System.Text.Json.Serialization;

namespace Shared;

public class MenuCategoryDto
{

    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public int RestaurantId { get; set; }
    
}