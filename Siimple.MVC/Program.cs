using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Siimple.BUSINESS.Services.Abstractions;
using Siimple.BUSINESS.Services.Interfaces;
using Siimple.CORE.Models;
using Siimple.DAL.DB;
using Siimple.DAL.Repositories.Abstractions;
using Siimple.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
 ) ;
//builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
//{
//    opt.Password.RequiredLength = 8;
//    opt.Password.RequireNonAlphanumeric = true;
//    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
//    opt.Lockout.MaxFailedAccessAttempts = 3;
//    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//})
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
