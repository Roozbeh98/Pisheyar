using Pisheyar.Application;
using Pisheyar.Application.Common.Interfaces;
//using Pisheyar.Infrastructure.Files;
using Pisheyar.Infrastructure.Identity;
using Pisheyar.Infrastructure.Persistence;
using Pisheyar.Infrastructure.Services;
//using IdentityModel;
//using IdentityServer4.Models;
//using IdentityServer4.Test;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Pisheyar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<PisheyarContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(PisheyarContext).Assembly.FullName)));

            services.AddScoped<IPisheyarContext>(provider => provider.GetService<PisheyarContext>());

            // configure strongly typed settings objects
            var jwtSection = configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(jwtSection);

            // configure jwt authentication
            var jwtSettings = jwtSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var issuer = jwtSettings.Issuer;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.FromSeconds(0)
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/ChatHub"))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };
                });

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IChatRoomService, ChatRoomService>();
            services.AddTransient<IZarinPalService, ZarinPalService>();

            return services;
        }
    }
}
