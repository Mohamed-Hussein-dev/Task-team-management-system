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
    public class LoginUserCommand : IRequest<BaseResponse<string>>
    {
        public LoginDto Dto { get; set; }
        public LoginUserCommand(LoginDto dto)
        {
            Dto = dto;
        }
    }
}
