using System;

namespace Shared;

public class MenuCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public Guid Uid { get; set; }
    public bool Active { get; set; }
    public int RestaurantId { get; set; }
    public int MenuItemCount { get; set; }
}