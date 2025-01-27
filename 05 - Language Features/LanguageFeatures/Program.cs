var builder = WebApplication.CreateBuilder(args);

// Enabling MVC in the Program.cs File in the LanguageFeatures Folder
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
