using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Linq.Expressions;
using System.Security.Claims;
using TaskTeamManagementSystem.Api.Helper;
using TaskTeamManagementSystem.Application.Features.Projects.Commands;
using TaskTeamManagementSystem.Application.Features.Projects.Commands.DTOs;
using TaskTeamManagementSystem.Application.Features.Tasks.Queries;

namespace TaskTeamManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProject(CreateProjectDto project)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new CreateProjectCommand(project, UserId);

            var res = await mediator.Send(command);

            if (res.Success) {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("{projectId}/tasks")]
        public async Task<IActionResult> getAllTasks(int projectId)
        {
            var query = new GetTasksByProjectQuery(projectId);
            var res = await mediator.Send(query);
            if(res.Success)
                 return Ok(res);
            return BadRequest(res);
        }
    }
}
