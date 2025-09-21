using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using TaskTeamManagementSystem.Api.Helper;
using TaskTeamManagementSystem.Application.Features.Projects.Commands;
using TaskTeamManagementSystem.Application.Features.Projects.Commands.DTOs;

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
            var command = new CreateProjectCommand(project , UserId);

            var res = await mediator.Send(command);

            if (res.Success) {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
