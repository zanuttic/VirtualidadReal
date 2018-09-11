using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualidadReal_WebAPP.Data;
using VirtualidadReal_WebAPP.Models;
using VirtualidadReal_WebAPP.Services;

namespace VirtualidadReal_WebAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IPaisesEnMomorias, PaisesEnMomorias>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void  Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleMagar = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userMagar = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] rolesNames = { "Administrador", "Coordinador", "Jugador", "Invitado" };

            IdentityResult result;
            foreach (var roleName in rolesNames)
            {
                var rolExist = await roleMagar.RoleExistsAsync(roleName);
                if (!rolExist)
                {
                    result = await roleMagar.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = await userMagar.FindByIdAsync("3e560ea8-dee4-482b-b3f0-ce612a10a1f5");
            await userMagar.AddToRoleAsync(user, "Administrador");




        }

    }
}
