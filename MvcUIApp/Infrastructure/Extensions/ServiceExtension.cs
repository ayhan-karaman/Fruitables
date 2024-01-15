using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcUIApp.Models;
using Repositories;
using Repositories.Concrete;
using Repositories.Contracts;
using Services.Concrete;
using Services.Contracts;

namespace MvcUIApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
              services.AddDbContext<RepositoryContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly("MvcUIApp"));
                options.EnableSensitiveDataLogging(true);
              });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
             services.AddIdentity<AppUser, AppRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase =false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
             })
             .AddEntityFrameworkStores<RepositoryContext>();
             
        }

        

        public static void ConfigureRepositoryRegistiration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
        public static void ConfigureServiceRegistiration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAddressService, AddressManager>();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.Cookie.Name = "StroreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));

        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(opt => {
                opt.LowercaseUrls = true;
                opt.AppendTrailingSlash = false;
            });
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opt => {
                opt.LoginPath = new PathString("/Account/Login");
                opt.ReturnUrlParameter =  CookieAuthenticationDefaults.ReturnUrlParameter;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }

    }
}