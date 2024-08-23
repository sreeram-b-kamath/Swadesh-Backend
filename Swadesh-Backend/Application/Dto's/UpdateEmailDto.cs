namespace Shared;



public class UpdateProfileDto
{
    public int Id { get; set; }
    public string CurrentEmail { get; set; }
    public string UpdateEmail { get; set; }
    public string RestaurantName { get; set; }
    public int Otp { get; set; }
    public string Logo { get; set; }
}