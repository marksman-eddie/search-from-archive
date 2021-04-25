using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArchiveSearch.Database;
using search_from_archive.Database;

namespace search_from_archive
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
            services.AddControllersWithViews();
            var options_gtng = new DbContextOptionsBuilder<ArchiveContext>().UseSqlServer(Configuration.GetSection("ConnectionString_gtng").Value).Options;
            var ArchiveContextServices_gtng = new ArchiveContext(options_gtng);
            services.AddSingleton(typeof(ArchiveContext), ArchiveContextServices_gtng);
            services.AddMemoryCache();
            services.AddSwaggerGen();

            var options_gms = new DbContextOptionsBuilder<ArchiveContext_gms>().UseSqlServer(Configuration.GetSection("ConnectionString_gms").Value).Options;
            var ArchiveContextServices_gms = new ArchiveContext_gms(options_gms);
            services.AddSingleton(typeof(ArchiveContext_gms), ArchiveContextServices_gms);
            services.AddMemoryCache();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseSwagger();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Search}/{action=SearchForm}/{id?}");
            });
        }
    }
}
