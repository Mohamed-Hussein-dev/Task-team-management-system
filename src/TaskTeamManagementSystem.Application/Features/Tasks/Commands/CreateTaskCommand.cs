using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<BaseResponse<TaskDto>>
    {
        public CreateTaskDto Dto { get; set; }
        public CreateTaskCommand(CreateTaskDto dto)
        {
            Dto = dto;
        }
    }
}
