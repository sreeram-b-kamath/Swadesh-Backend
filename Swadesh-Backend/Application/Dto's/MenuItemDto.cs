using System;
using System.Collections.Generic;

namespace Shared;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MenuCategoryOrder { get; set; }
    public int MenuCategoryId { get; set; }
    public string MenuCategoryName { get; set; }
    public int[] MenuFilterIds { get; set; }
    public string PrimaryImage { get; set; }
    public string[] Images { get; set; }
    public List<string> Icons { get; set; }
    public int MenuFilterId { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public bool InStock { get; set; }
    public int MenuOrder { get; set; }
    public int Rating { get; set; }
    public Guid Uid { get; set; }
    public bool IsActive { get; set; }
}

public class MenuDto
{
    public string languageCode { get; set; }
    public List<Menu> Menu { get; set; }
}