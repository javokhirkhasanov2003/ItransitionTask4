namespace BlazorApp2.ViewModels;

public class UserVM : IHaveNumber
{
    public int Nr { get; set; }
    public string Id { get; set; }
    public string? Email { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public DateTimeOffset? RegistrationDate { get; set; }
    public bool IsBlocked { get; set; }
}