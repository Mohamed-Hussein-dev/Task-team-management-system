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
    public class GetUserProjectsQuery : IRequest<BaseResponse<List<ProjectDto>>>
    {
        public string UserId { get; set; }
        public GetUserProjectsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
