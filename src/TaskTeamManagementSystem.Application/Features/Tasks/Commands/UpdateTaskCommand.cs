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
    public class UpdateTaskCommand : IRequest<BaseResponse<bool>>
    {
        public UpdateTaskDto Dto { get; set; }
        public UpdateTaskCommand(UpdateTaskDto dto)
        {
            Dto = dto;
        }
    }
}
