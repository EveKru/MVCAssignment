using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add your services here...
builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserEntity>( x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/SignIn"; // login page route 
    options.LogoutPath = "/Auth/SignOut"; // logout page route 

    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //time to be logged in
    options.SlidingExpiration = true; // time reset when site rendering

    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // for security
    options.Cookie.HttpOnly = true; // for security

});

// services
builder.Services.AddScoped<AdressService>();
builder.Services.AddScoped<AdressRepository>();

var app = builder.Build();

app.UseRouting();

//added
app.UseAuthentication();

app.UseAuthorization();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
