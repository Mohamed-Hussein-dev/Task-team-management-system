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
    public class CreateProjectCommand : IRequest<BaseResponse<ProjectDto>>
    {
        public CreateProjectDto Dto { get; set; }
        public string LeaderId { get; set; }
        public CreateProjectCommand(CreateProjectDto dto , string leaderId)
        {
            Dto = dto;
            LeaderId = leaderId;
        }
    }
}
