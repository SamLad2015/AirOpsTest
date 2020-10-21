using AirOpsTest.Entities;
using AirOpsTest.Interfaces;
using AirOpsTest.MappingProfiles;
using AirOpsTest.Repositories;
using AirOpsTest.Services;
using AutoMapper;
using AirOpsTest.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AirOpsTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddCustomCors("AllowAllOrigins");
            services.AddScoped<IReadRepository<StatusMessageEntity>, ReadRepository<StatusMessageEntity>>();
            services.AddScoped<IWriteRepository<StatusMessageEntity>, WriteRepository<StatusMessageEntity>>();
            services.AddScoped<IStatusMessageService, StatusMessageService>();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllers();
            services.AddVersioning();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(StatusMessageMappings));
        }
        
        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory, 
            IWebHostEnvironment env, 
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.AddProductionExceptionHandling(loggerFactory);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseExceptionHandler("/error"); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}