using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Projects.Commands;
using TaskTeamManagementSystem.Application.Interfaces;

namespace TaskTeamManagementSystem.Application.Features.Projects.Handlers
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProjectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var Project = await unitOfWork.Projects.GetByIdAsync(request.Dto.ProjectId);
            if (Project == null) {
                return BaseResponse<bool>.Fail("Project does not exist");
            }

            Project.Title = request.Dto.Title ?? Project.Title;
            Project.Description = request.Dto.Description ?? Project.Description;

            unitOfWork.Projects.Update(Project);

            var UpdateRes = await unitOfWork.CommitChangesAsync();

            if (UpdateRes == 0)
                return BaseResponse<bool>.Fail("Update Project Faild");

            return BaseResponse<bool>.Ok(true, "Updated Correctrly");
        }
    }
}
