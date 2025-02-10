using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Se registran los servicios para trabajar con controladores y vistas en MVC.
builder.Services.AddControllersWithViews();

// Registra StoreDbContext para el acceso a la base de datos mediante Entity Framework Core.
builder.Services.AddDbContext<StoreDbContext>(opts => 
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

// Configura la inyección de dependencias para que EFStoreRepository sea la implementación de IStoreRepository.
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// Agrega el servicio de soporte para las Razor Pages.
builder.Services.AddRazorPages();

// Agrega el servicio de soporte para la sesión.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Build se utiliza para crear la aplicación.
var app = builder.Build();

// Configura el uso de archivos estáticos.
app.UseStaticFiles();

// Configura el uso de sesiones.
app.UseSession();

app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });

// Rutas personalizadas para la paginación.
app.MapControllerRoute("pagination", "Products/Page{productPage}", new
{
    Controller = "Home",
    action = "Index"
});

// Rutas por defecto para MVC.
app.MapDefaultControllerRoute();

// Rutas por defecto para Razor Pages.
app.MapRazorPages();

// Sembrado de datos en la base si no existen.
SeedData.EnsurePopulated(app);

app.Run();
