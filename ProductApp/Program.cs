using Microsoft.EntityFrameworkCore;
using ProductApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductAppContext") ?? throw new InvalidOperationException("Connection string 'ProductAppContext' not found.")));
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
