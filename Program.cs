using BaiTap_Repository_Pattern.Data;
using BaiTap_Repository_Pattern.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IThietBiRepository, ThietBiRepository>();

var app = builder.Build();

var databaseDirectory = Path.Combine(app.Environment.ContentRootPath, "App_Data");
Directory.CreateDirectory(databaseDirectory);

await using (var scope = app.Services.CreateAsyncScope())
{
    var database = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await database.Database.EnsureCreatedAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ThietBi/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ThietBi}/{action=Index}/{id?}");

app.Run();
