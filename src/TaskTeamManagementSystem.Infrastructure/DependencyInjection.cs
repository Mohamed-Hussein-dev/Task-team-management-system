using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskTeamManagementSystem.Application.Features.Auth.Interfaces;
using TaskTeamManagementSystem.Application.Interfaces;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;
using TaskTeamManagementSystem.Domain.Entities.Identtity;
using TaskTeamManagementSystem.Infrastructure.Identity;
using TaskTeamManagementSystem.Infrastructure.Persistence;
using TaskTeamManagementSystem.Infrastructure.Persistence.Repositories;

namespace TaskTeamManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) {

            #region AddDbContext
            services.AddDbContext<ApplicationDbContext>(Options =>
                Options.UseSqlServer(config.GetConnectionString("DefultConnectionString"))   
            );
            #endregion

            #region AddIdentity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),

                     ValidateIssuer = true,
                     ValidIssuer = config["Jwt:Issuer"],

                     ValidateAudience = true,
                     ValidAudience = config["Jwt:Audience"],

                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });
            #endregion

            #region Jwt Generator Register
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            #endregion

            #region ADD Uint of work
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region ADD Project Repo
            services.AddScoped<IProjectRepository, ProjectRepository>();
            #endregion

            #region ADD Task Repo
            services.AddScoped<ITaskRepository, TaskRepository>();
            #endregion

            return services;

        }
    }
}
