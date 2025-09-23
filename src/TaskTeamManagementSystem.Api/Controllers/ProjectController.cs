using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Linq.Expressions;
using System.Security.Claims;
using TaskTeamManagementSystem.Api.Helper;
using TaskTeamManagementSystem.Application.Features.Projects.Commands;
using TaskTeamManagementSystem.Application.Features.Projects.DTOs;
using TaskTeamManagementSystem.Application.Features.Projects.Queries;
using TaskTeamManagementSystem.Application.Features.Tasks.Queries;

namespace TaskTeamManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Authorize(policy: "ProjectLeaderPolicy")]
        public async Task<IActionResult> CreateProject(CreateProjectDto project)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new CreateProjectCommand(project, UserId);

            var res = await mediator.Send(command);

            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("{projectId}/tasks")]
        public async Task<IActionResult> getAllTasks(int projectId)
        {
            var query = new GetTasksByProjectQuery(projectId);
            var res = await mediator.Send(query);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPut("{projectId}")]
        [Authorize(policy: "ProjectLeaderPolicy")]
        public async Task<IActionResult> UpdateProjct(UpdateProjectDto updateProjectDto)
        {
            var command = new UpdateProjectCommand(updateProjectDto);
            var res = await mediator.Send(command);
            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }

        [HttpDelete("{projectId}")]
        [Authorize(policy: "ProjectLeaderPolicy")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var command = new DeleteProjectCommand(projectId);
            var res = await mediator.Send(command);
            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsereProjects()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetUserProjectsQuery(UserId);
            var res = await mediator.Send(query);

            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            var query = new GetProjectByIdQuery(projectId);
            var res = await mediator.Send(query);
            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }
    }
}
