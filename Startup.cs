using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reservation.Repositories;
using Reservation.Services;

namespace Reservation
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
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddDbContext<ReservationContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("ReservationContext")));
            
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ILogRecordRepository, LogRecordRepository>();
            services.AddScoped<IResourceGroupRepository, ResourceGroupRepository>();
            services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<ILogRecordService, LogRecordService>();
            services.AddScoped<IResourceGroupService, ResourceGroupService>();            
            services.AddScoped<IResourceTypeService, ResourceTypeService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddHostedService<BackgroundServices.RequestProcessingService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
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

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
