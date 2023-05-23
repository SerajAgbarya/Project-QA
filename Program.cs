<<<<<<< HEAD
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebApplication5.Data;
using WebApplication5.Validators;
using OfficeOpenXml;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddScoped<ExcelDbContext>(); // Register ExcelDbContext
services.AddTransient<UserValidator>(provider => new UserValidator(provider.GetRequiredService<ExcelDbContext>(), "C:\\Users\\USER\\Desktop\\Project-QA\\database.xlsx")); // Register UserValidator with file path

// Set ExcelPackage license context
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
<<<<<<< HEAD
=======
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

<<<<<<< HEAD
app.MapControllerRoute(
    name: "user",
    pattern: "User/{action=Login}/{id?}",
    defaults: new { controller = "User" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Homepage}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bird}/{action=Create}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brid}/{action=Index1}/{id?}");
=======
>>>>>>> e0c8543973a1f2d6f1d0cfa64a66e60368cea978
app.Run();
