using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Projects.DTOs;

namespace TaskTeamManagementSystem.Application.Features.Projects.Commands
{
    public class UpdateProjectCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateProjectDto Dto { get; set; }
        public UpdateProjectCommand(UpdateProjectDto dot)
        {
            Dto = dot;
        }
    }
}
