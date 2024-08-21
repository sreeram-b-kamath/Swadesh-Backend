namespace Shared;


public class RestDto
{
    public int Id { get; set; }
    public string EmailId { get; set; }
    public string RestaurantName { get; set; }
    public bool Active { get; set; }
    public int RestaurantCount { get; set; }
    public int ActiveRestaurant { get; set; }
    public int InActiveRestaurant { get; set; }
}