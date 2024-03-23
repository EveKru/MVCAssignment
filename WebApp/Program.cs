using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add your services here...
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserEntity>( x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/SignIn"; // Set your custom login page route here
    //time to be logged in
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
