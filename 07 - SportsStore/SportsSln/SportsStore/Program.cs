using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Add MVC services to the container

builder.Services.AddDbContext<StoreDbContext>(opts => 
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();                       // Enable static files
app.MapDefaultControllerRoute();            // Default route for MVC

app.Run();
