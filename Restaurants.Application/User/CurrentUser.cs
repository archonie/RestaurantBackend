namespace Restaurants.Application.User;

public record CurrentUser(string UserId, string Email, IEnumerable<string> Roles)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}