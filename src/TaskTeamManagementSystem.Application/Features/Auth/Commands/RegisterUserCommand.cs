using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Auth.DTOs;
using TaskTeamManagementSystem.Application.Features.Common.Responses;

namespace TaskTeamManagementSystem.Application.Features.Auth.Commands
{
    public class RegisterUserCommand : IRequest<BaseResponse<string>>
    {
        public RegisterDto Dto { get; set; }
        public RegisterUserCommand(RegisterDto dto)
        {
            Dto = dto;
        }
    }
}
