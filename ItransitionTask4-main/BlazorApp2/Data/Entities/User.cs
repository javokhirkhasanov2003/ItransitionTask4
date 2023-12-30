using Microsoft.AspNetCore.Identity;

namespace BlazorApp2.Data.Entities;

public class User : IdentityUser
{
    public string Name { get; set; }
    public bool IsBlocked { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public DateTimeOffset? RegistrationDate { get; set; }
}