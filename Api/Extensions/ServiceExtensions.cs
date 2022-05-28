﻿using Contracts;
using Entities.ConfigurationModels;
using Entities.Database;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Contracts;
using Service;
using Service.Contracts;
using Shared.Utils;
using System.Text;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    //.AllowAnyOrigin()
                    .WithOrigins("http://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination");
                });
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SqlConnection")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 5;
                o.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, 
            IConfiguration configuration) 
        { 
            var jwtConfiguration = new JwtConfiguration(); 
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration); 
            var secretKey = Environment.GetEnvironmentVariable(Constants.JWT_KEY); 
            services.AddAuthentication(opt => 
            { 
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
            }).AddJwtBearer(options => 
            { 
                options.TokenValidationParameters = new TokenValidationParameters 
                { 
                    ValidateIssuer = true, 
                    ValidateAudience = true, 
                    ValidateLifetime = true, 
                    ValidateIssuerSigningKey = true, 
                    ValidIssuer = jwtConfiguration.ValidIssuer, 
                    ValidAudience = jwtConfiguration.ValidAudience, 
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey)) 
                }; 
            }); 
        }

        public static void AddJwtConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        }
    }
}
