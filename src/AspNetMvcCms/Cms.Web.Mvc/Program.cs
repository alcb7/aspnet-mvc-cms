using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connStr = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connStr))
{
    throw new InvalidOperationException("Connection string is not found!");
}
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connStr);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    // DbContext'imizi servis saðlayýcýdan istiyoruz
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Uygulamamýzý her çalýþtýrdýðýmýzda db'yi silip tekrar oluþturuyoruz:
   await dbContext.Database.EnsureDeletedAsync();

    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();
