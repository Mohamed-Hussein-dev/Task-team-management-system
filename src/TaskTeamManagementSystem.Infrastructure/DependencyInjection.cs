using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TaskTeamManagementSystem.Domain.Entities.Identtity;
using TaskTeamManagementSystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaskTeamManagementSystem.Application.Features.Auth.Interfaces;
using TaskTeamManagementSystem.Infrastructure.Identity;

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

            return services;

        }
    }
}
