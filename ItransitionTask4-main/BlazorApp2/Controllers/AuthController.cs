using BlazorApp2.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;

    public AuthController(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        Console.WriteLine("Logout");
        await _signInManager.SignOutAsync();
        return RedirectToRoute("~/");
    }
}