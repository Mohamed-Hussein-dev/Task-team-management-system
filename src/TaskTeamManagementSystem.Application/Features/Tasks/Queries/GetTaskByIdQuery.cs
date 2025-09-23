using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Queries
{
    public class GetTaskByIdQuery : IRequest<BaseResponse<TaskDto>>
    {
        public int TaskId { get; set; }
        public GetTaskByIdQuery(int taskId)
        {
            TaskId = taskId;
        }
    }
}
