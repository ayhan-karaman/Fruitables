using MvcUIApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryRegistiration();
builder.Services.ConfigureServiceRegistiration();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints => {
     endpoints.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}/{id?}");
     endpoints.MapControllers();
});
app.ConfigureAndCheckMigration();
app.Run();
