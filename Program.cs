using BaiTap_JavaScript_JQuery_Ajax.Data;
using BaiTap_JavaScript_JQuery_Ajax.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IThietBiRepository, ThietBiRepository>();

var app = builder.Build();

var databasePath = Path.Combine(app.Environment.ContentRootPath, "App_Data");
Directory.CreateDirectory(databasePath);

await using (var scope = app.Services.CreateAsyncScope())
{
    var database = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await database.Database.EnsureCreatedAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/LopHoc/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LopHoc}/{action=Index}/{id?}");

app.Run();
