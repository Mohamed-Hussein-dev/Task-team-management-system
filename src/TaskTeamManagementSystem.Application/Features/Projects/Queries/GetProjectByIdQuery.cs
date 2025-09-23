using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Projects.DTOs;

namespace TaskTeamManagementSystem.Application.Features.Projects.Queries
{
    public class GetProjectByIdQuery : IRequest<BaseResponse<ProjectDto>>
    {
        public int ProjectId { get; set; }
        public GetProjectByIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
