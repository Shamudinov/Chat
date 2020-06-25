using AutoMapper;
using Chat.Helpers.Enums;
using Chat.Models;
using Chat.Models.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChatDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            
            services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            
            services.AddIdentity<User, IdentityRole>(options => 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
               .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authorization}/{action=Login}");
            });
        }
    }
}
