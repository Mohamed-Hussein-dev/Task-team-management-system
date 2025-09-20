using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using TaskTeamManagementSystem.Api.Policies.TeamLeader;

namespace TaskTeamManagementSystem.Api.Policies
{
    public static class PoliciesRegister
    {
        public static IServiceCollection AddPolicies(this IServiceCollection services)
        {
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ProjectLeaderPolicy", policy => 
                policy.Requirements.Add(new ProjectLeaderRequirement()));
            });


            services.AddScoped<IAuthorizationHandler, ProjectLeaderHandler>();

            return services;
        }
    }
}
