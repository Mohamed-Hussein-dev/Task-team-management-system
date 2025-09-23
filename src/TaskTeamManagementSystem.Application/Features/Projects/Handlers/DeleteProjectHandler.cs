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
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProjectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var Project = await unitOfWork.Projects.GetByIdAsync(request.ProjectId);
            if (Project == null)
            {
                return BaseResponse<bool>.Fail("Project does not exist");
            }

            unitOfWork.Projects.Remove(Project);

            var DeleteRes = await unitOfWork.CommitChangesAsync();

            if (DeleteRes == 0)
                return BaseResponse<bool>.Fail("Delete Project Faild");

            return BaseResponse<bool>.Ok(true, "Delete Correctrly");
        }
    }
}
