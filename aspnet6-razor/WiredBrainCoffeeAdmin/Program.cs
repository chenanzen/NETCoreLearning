using WiredBrainCoffeeAdmin.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WiredContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WiredBrain")
        )
    );
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();


// Setup middleware pipelines
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();