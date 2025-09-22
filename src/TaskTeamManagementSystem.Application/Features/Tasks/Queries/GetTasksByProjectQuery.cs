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
    public class GetTasksByProjectQuery : IRequest<BaseResponse<List<TaskDto>>>
    {
        public int ProjectId {  get; set; }
        public GetTasksByProjectQuery(int projectId) {
            ProjectId = projectId;
        }
    }
}
