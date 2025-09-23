using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using TaskTeamManagementSystem.Application.Features.Tasks.Commands;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;
using TaskTeamManagementSystem.Application.Features.Tasks.Queries;

namespace TaskTeamManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator mediator;

        public TaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("{projectId}")]
        [Authorize(policy: "ProjectLeaderPolicy")]
        public async Task<IActionResult> AddTask(CreateTaskDto task)
        {
            var command = new CreateTaskCommand(task);
            var res = await mediator.Send(command);

            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPut("{projectId}/{TaskId}")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto taskDto)
        {
            var Command = new UpdateTaskCommand(taskDto);
            var res = await mediator.Send(Command);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("{projectId}/{taskId}")]
        //[Authriz(policy: "deleteTaskPolicy")] just project leader can delete 
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var command = new DeleteTaskCommand(taskId);
            var DeleteRes = await mediator.Send(command);
            if (DeleteRes.Success)
                return Ok(DeleteRes);
            return BadRequest(DeleteRes);
        }

        [HttpPost("{projectId}/{TaskId}/assign/{userEmail}")]
        [Authorize(policy: "ProjectLeaderPolicy")]
        public async Task<IActionResult> AssignTask(int TaskId, string userEmail)
        {
            var command = new AssignTaskCommand(userEmail, TaskId);
            var res = await mediator.Send(command);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);

        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> getTaskById(int taskId)
        {
           var query = new GetTaskByIdQuery(taskId);
           var res = await mediator.Send(query);
           if(res.Success)
               return Ok(res);
           return BadRequest(res);
        }
    }

}
