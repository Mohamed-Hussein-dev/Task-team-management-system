using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;
using TaskTeamManagementSystem.Application.Features.Tasks.Helper;
using TaskTeamManagementSystem.Application.Features.Tasks.Queries;
using TaskTeamManagementSystem.Application.Interfaces;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, BaseResponse<TaskDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetTaskByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<TaskDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);
            if (task == null) {
                return BaseResponse<TaskDto>.Fail("Task not Exisit");
            }
            var TaskDto = new TaskDto()
            {
                TaskId = request.TaskId,
                Title = task.Title,
                Description = task.Description,
                AssignedUserId = task.AssigneeUserId,
                CreatedAt = task.CreatedAt,
                ProjectId = task.ProjId,
                Status = Utility.getStatus(task.Status),
                Type = Utility.getType(task.Type)
            };
            return BaseResponse<TaskDto>.Ok(TaskDto);
        }
    }
}
