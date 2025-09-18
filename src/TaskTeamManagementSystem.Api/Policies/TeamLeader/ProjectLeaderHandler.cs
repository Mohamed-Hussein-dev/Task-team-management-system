using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
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
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProjectLeaderRequirement requirement)
        {
            var UserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null)
                return Task.CompletedTask;

            var routeValues = httpContextAccessor.HttpContext?.Request.RouteValues;

            if(routeValues == null || !routeValues.ContainsKey("projectId"))
                return Task.CompletedTask;

            var projectId = int.Parse(routeValues["projectId"].ToString());

            /*
             var isLeader = await dbContext.Projects.AnyAsync(p => p.Id == projectId && p.TeamLeaderId == userId);

            if (isLeader)
            {
                context.Succeed(requirement);
            }
            */
            return Task.CompletedTask;
        }
    }
}
