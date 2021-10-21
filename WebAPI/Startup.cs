using Business.DependencyResolvers;
using Business.Extensions;
using Business.Hubs;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Extensions;

namespace WebAPI
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

            services.AddCors();

            services.AddJwtAuthentication(Configuration); // For JWT Authentication

            // For Layers Dependency
            services.AddDependencyResolvers(
                new CoreModule(),
                new BusinessModule()
            );

            services.AddSwagger(); // For Swagger
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceTool.ServiceProvider = app.ApplicationServices;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseCustomExceptionMiddleware();

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // For Allow Any Origin
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseTranslates(); // For Translates

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRequestUser(); // For Authorization Security

            app.CreateSuperUser(); // For Create Default Super User. !!! Don't Use This Method for Production Mode

            app.UseRefreshTokenEndDate(false); // For RefreshTokenEndDate.

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SystemHub>("/systemhub"); // For SystemHub
            });
        }
    }
}