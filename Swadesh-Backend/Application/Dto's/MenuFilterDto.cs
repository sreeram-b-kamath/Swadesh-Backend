using System.Collections.Generic;

namespace Shared;

public class MenuFilterDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int RestaurantID {  get; set; }
    public bool Active { get; set; }

}

public class FiltersDto
{
    public string languageCode { get; set; }
    public List<MenuFilterDto> Filters { get; set; }
}