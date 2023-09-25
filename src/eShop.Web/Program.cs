using AutoMapper;
using eShop.Data;
using eShop.Modules;
using eShop.Modules.ProductCatalog;
using eShop.Modules.ShoppingCart;
using eShop.Pages.ProductCatalog;
using eShop.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace eShop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("eShop.EntityFrameworkCore.SqlServer")));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        builder.Services.AddRazorPages()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(ProductCatalogResource));
                };
            });

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { "en-US", "pt-BR" };
            options.SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
        });

        builder.Services.AddTransient<ProductCatalogDbService>();
        builder.Services.AddTransient<CartRepositoryInterface, CartDbService>();


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("productcatalog", new OpenApiInfo { Title = "eShop.Web - ProductCatalog", Version = "v1" });
            c.SwaggerDoc("shoppingcart", new OpenApiInfo { Title = "eShop.Web - ShoppingCart", Version = "v1" });
        });

        builder.Services.AddAutoMapper((config) =>
        {
            config.AddProfile<MappingProfile>();
            config.AddProfile<ProductCatalogMappingProfile>();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/productcatalog/swagger.json", "ProductCatalog - v1");
                c.SwaggerEndpoint("/swagger/shoppingcart/swagger.json", "ShoppingCart - v1");
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllers();

        app.Run();
    }
}