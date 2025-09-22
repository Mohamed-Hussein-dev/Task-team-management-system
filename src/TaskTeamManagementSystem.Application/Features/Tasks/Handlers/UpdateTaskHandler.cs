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
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateTaskHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.Tasks.GetByIdAsync(request.Dto.TaskId);

            if (task == null)
            {
                return BaseResponse<bool>.Fail("There is Not Such Task");
            }
            task.Title = request.Dto.Title ?? task.Title;
            task.Description = request.Dto.Description ?? task.Description;
            task.Status = getType(request.Dto.Status) ?? task.Status;
            task.Type = getStatus(request.Dto.Type) ?? task.Type;

            unitOfWork.Tasks.Update(task);

            int UpdateRes = await unitOfWork.CommitChangesAsync();

            if (UpdateRes == 0) {
                return BaseResponse<bool>.Fail("Fail to update task");
            }

            return BaseResponse<bool>.Ok(true, "Update Task Sucssefuly");

        }
        int? getStatus(string type)
        {
            // 0 - NotStarted , 1 - InProgress , 2 - Done
            return type switch
            { 
                "NotStarted" => 0,
                "InProgress" => 1,
                "Done" => 2,
                _ => null
            
            };
        }
        int? getType(string type)
        {
            return type switch
            {
                "Task" => 0,
                "Bug" => 1,
                "Feature" => 2,
                _ => null
            };
            // 0 - Task , 1 - Bug , 2 - Feature 

        }
    }
}
