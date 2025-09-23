using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Auth.Interfaces;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Application.Features.Auth.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponse<string>>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IJwtGenerator JwtGenerator;

        public LoginUserCommandHandler(UserManager<AppUser> userManager , IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.JwtGenerator = jwtGenerator;
        }


        public async Task<BaseResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = await userManager.FindByEmailAsync(request.Dto.Email);

            if (userIdentity == null) 
            {
                return BaseResponse<string>.Fail("Email or Password is Wrong");
            }

            var correctPasswork = await userManager.CheckPasswordAsync(userIdentity, request.Dto.Password);

            if (correctPasswork)
            {
                var token = await JwtGenerator.GenerateJwtAsync(userIdentity, userManager);
                return BaseResponse<string>.Ok(token);
            }
            return BaseResponse<string>.Fail("Email or Password is Wrong");
        }
    }
}
