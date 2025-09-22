using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.Commands;
using TaskTeamManagementSystem.Application.Interfaces;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Handlers
{
    public class AssignTaskHandler : IRequestHandler<AssignTaskCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;

        public AssignTaskHandler(IUnitOfWork unitOfWork , UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<BaseResponse<bool>> Handle(AssignTaskCommand request, CancellationToken cancellationToken)
        {
            var User = await userManager.FindByEmailAsync(request.UserEmail);

            if (User == null) {
                return BaseResponse<bool>.Fail("User not exist");
            }

            var Task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);

            if (Task == null) {
                return BaseResponse<bool>.Fail("Task not exist");
            }

            Task.AssigneeUserId = User.Id;

            var AssignTask = await unitOfWork.CommitChangesAsync();

            if(AssignTask == 0)
                return BaseResponse<bool>.Fail("Assign Task was Failed");
            
            return BaseResponse<bool>.Ok(true, "Task Assigned Correctly");
        }
    }
}
