using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;

namespace TaskTeamManagementSystem.Application.Features.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<BaseResponse<bool>>
    {
        public int ProjectId { get; set; }
        public DeleteProjectCommand(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
