using MediatR;

using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Tasks.Commands;
using TaskTeamManagementSystem.Application.Features.Tasks.DTOs;
using TaskTeamManagementSystem.Application.Features.Tasks.Helper;
using TaskTeamManagementSystem.Application.Interfaces;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, BaseResponse<TaskDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateTaskHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<TaskDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new ProjectTask()
            {
                Title = request.Dto.Title,
                Description = request.Dto.Description,
                Type = request.Dto.Type,
                ProjId = request.Dto.projectId
            };

            await unitOfWork.Tasks.AddAsync(task);

            var AddTaskRes = await unitOfWork.CommitChangesAsync();

            if (AddTaskRes == 0)
            {
                return BaseResponse<TaskDto>.Fail("Create Task is Failed");
            }
            var TaskDto = new TaskDto()
            {
                TaskId = task.Id,
                Title = request.Dto.Title,
                Description = request.Dto.Description,
                Type = Utility.getType(request.Dto.Type),
                ProjectId = request.Dto.projectId                

            };
            return BaseResponse<TaskDto>.Ok(TaskDto, "Task Created Successfully");

        }

        
    }
}
