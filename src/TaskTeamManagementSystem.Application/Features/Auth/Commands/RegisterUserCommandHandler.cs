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
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponse<string>>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IJwtGenerator jwtGenerator;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager , IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }
        public async Task<BaseResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var identityResult = await userManager.FindByEmailAsync(request.Dto.email);

            if (identityResult != null) {
                return BaseResponse<string>.Fail("Email is already used");
            }

            var user = new AppUser()
            {
                FirstName = request.Dto.firstName,
                LastName = request.Dto.lastName,
                UserName = request.Dto.email.Split('@')[0],
                Email = request.Dto.email
            };

           var res =  await userManager.CreateAsync(user , request.Dto.password);

            var createdUser = await userManager.FindByEmailAsync(request.Dto.email);

            if (createdUser is null)
            {
                var errors = res.Errors.Select(e => e.Description);
                return BaseResponse<string>.Fail("Account Creation fail" , errors);
            }

            var isRoleAssignedSuccessfully = await userManager.AddToRoleAsync(user, "user");

            if (!isRoleAssignedSuccessfully.Succeeded)
            {
                return BaseResponse<string>.Fail("Role assignment failed");
            }

            var RegisterToken = await jwtGenerator.GenerateJwtAsync(createdUser, userManager);

            return BaseResponse<string>.Ok(RegisterToken, "User Register sussfuly");

        }
    }
}
