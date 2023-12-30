using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Areas.Identity;
using BlazorApp2.Data;
using BlazorApp2.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMudServices();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 1;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;
        
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication();

builder.Services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider>();

var app = builder.Build();

// add database migration logic
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
}
else 
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();