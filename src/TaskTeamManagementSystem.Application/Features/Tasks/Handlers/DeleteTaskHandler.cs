using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.Commands;
using TaskTeamManagementSystem.Application.Interfaces;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand , BaseResponse<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteTaskHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await unitOfWork.Tasks.GetByIdAsync(request.TaskId);
            if (Task == null) {
                return BaseResponse<bool>.Fail("Task Not Exist");
            }

            int deleteRes = await unitOfWork.CommitChangesAsync();

            if (deleteRes == 0) {
                return BaseResponse<bool>.Fail("Delete Task was Failed");
            }

            return BaseResponse<bool>.Ok(true, "Task Deleted sucssfully");
        }
    }
}
