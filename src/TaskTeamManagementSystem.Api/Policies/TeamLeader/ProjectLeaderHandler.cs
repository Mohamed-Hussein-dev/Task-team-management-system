using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;
using TaskTeamManagementSystem.Infrastructure.Persistence;

namespace TaskTeamManagementSystem.Api.Policies.TeamLeader
{
    public class ProjectLeaderHandler : AuthorizationHandler<ProjectLeaderRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;

        public ProjectLeaderHandler(IHttpContextAccessor httpContextAccessor , ApplicationDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ProjectLeaderRequirement requirement)
        {
            var UserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null)
                return;

            var routeData = httpContextAccessor.HttpContext?.Request.RouteValues;
            if (routeData?["projectId"] is string projectIdString && int.TryParse(projectIdString, out var projectId))
            {
                var isLeader = await dbContext.Projects.AnyAsync(p => p.Id == projectId && p.LeaderId == UserId);
                if (isLeader)
                {
                    context.Succeed(requirement);
                }
            }
 
        }
    }
}
