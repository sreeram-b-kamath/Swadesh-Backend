using Models;
using Shared;
namespace Dtos;

public class RestaurantDto
{
    public string LanguageCode { get; set; }
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Logo { get; set; }
    public string Background { get; set; }
    public string Cuisine { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Province { get; set; }
    public string State { get; set; }
    public string Contact { get; set; }
    public Guid Session { get; set; }
    public List<MenuFilter> FiltersDtos { get; set; }
    public List<MenuCategoryDto> MenuCategoryDtos { get; set; }
}