using Microsoft.EntityFrameworkCore;
using RH.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de Entity Framework con SQL Server
builder.Services.AddDbContext<TSEContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticaUtilidadesConnection")));

builder.Services.AddDbContext<OferenteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("practicantesConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map the controllers that use attribute routing
app.MapControllers(); // This maps controllers with attributes like [HttpGet] and [HttpPost]

// Configure a default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
