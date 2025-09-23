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
    public class GetTasksByProjectHandler : IRequestHandler<GetTasksByProjectQuery, BaseResponse<List<TaskDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetTasksByProjectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<TaskDto>>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            var Tasks = await unitOfWork.Tasks.GetAllAsync(task => task.ProjId == request.ProjectId);
            var res = new List<TaskDto>();
            foreach (var task in Tasks)
            {
                res.Add(new TaskDto() { 
                    ProjectId = task.ProjId,
                    TaskId = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = Utility.getStatus(task.Status),
                    Type = Utility.getType(task.Type),
                    AssignedUserId = task.AssigneeUserId,
                    CreatedAt = task.CreatedAt,
                });
            }
            return BaseResponse<List<TaskDto>>.Ok(res);
        }
    }
}
