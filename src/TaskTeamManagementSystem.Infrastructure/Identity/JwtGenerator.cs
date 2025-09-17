using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Auth.Interfaces;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Infrastructure.Identity
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration config;

        public JwtGenerator(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<string> GenerateJwtAsync(AppUser user, UserManager<AppUser> userManager)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email,user.Email!),
            };

            var Roles = await userManager.GetRolesAsync(user);

            foreach (var Role in Roles) {
                userClaims.Add(new Claim(ClaimTypes.Role, Role));
            }

            var authKeyInByets = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));

            var JwtObject = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(double.Parse(config["Jwt:DurationDay"]!)),
                signingCredentials: new SigningCredentials(authKeyInByets, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(JwtObject);
        }
    }
}
