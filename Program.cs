using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);

//DI for accessing data
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();


//let .net this is mvc app
builder.Services.AddControllersWithViews();


//Add the db context configuration
builder.Services.AddDbContext<PieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PieShopConnectionString"]);
});

var app = builder.Build();

app.UseStaticFiles(); //used for returning static files through www.root folder

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // constains more dev info for trobleshooting
}

app.MapDefaultControllerRoute(); // End point controller middleware.

SeedData.Seed(app);

app.Run();
