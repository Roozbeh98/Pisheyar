using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Pisheyar.Application;
using Pisheyar.Infrastructure;
using Pisheyar.Infrastructure.Identity;
using Pisheyar.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebUI.Swashbuckle;
using WebUI.Services;
using Microsoft.AspNetCore.Http;
using Pisheyar.Infrastructure.Persistence;
using FluentValidation.AspNetCore;
using WebUI.Common;
using Pisheyar.Infrastructure.Services;
using WebUI.Hubs;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration, Environment);

            services.AddSignalR().AddHubOptions<ChatHub>(options =>
            {
                options.EnableDetailedErrors = true;
            });

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHealthChecks()
                .AddDbContextCheck<PisheyarContext>();

            services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000")
                    .WithOrigins("http://127.0.0.1:3000")
                    .WithOrigins("http://localhost:3001")
                    .WithOrigins("http://127.0.0.1:3001")
                    .WithOrigins("http://localhost:3002")
                    .WithOrigins("http://127.0.0.1:3002")
                    .WithOrigins("http://localhost:5500")
                    .WithOrigins("http://127.0.0.1:5500")
                    .AllowCredentials();
            }));
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IPisheyarContext>())
                .AddNewtonsoftJson();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCustomExceptionHandler();
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwaggerDocumentation();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/ChatHub");
            });
        }
    }
}
