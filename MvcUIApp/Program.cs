using System.Security.Claims;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using MvcUIApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureSession();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureRepositoryRegistiration();
builder.Services.ConfigureServiceRegistiration();


builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
     
     endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
     endpoints.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}/{id?}");
     
     endpoints.MapRazorPages();
     
     endpoints.MapControllers();
});
app.ConfigureAndCheckMigration();
app.ConfigureDefaultAdminUserAsync();


app.Run();
