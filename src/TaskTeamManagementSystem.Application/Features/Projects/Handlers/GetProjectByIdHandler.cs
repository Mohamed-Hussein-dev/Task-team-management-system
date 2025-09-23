using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Projects.DTOs;
using TaskTeamManagementSystem.Application.Features.Projects.Queries;
using TaskTeamManagementSystem.Application.Interfaces;

namespace TaskTeamManagementSystem.Application.Features.Projects.Handlers
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, BaseResponse<ProjectDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProjectByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ProjectDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var Project = await unitOfWork.Projects.GetByIdAsync(request.ProjectId);
            if (Project == null)
            {
                return BaseResponse<ProjectDto>.Fail("Project does not exist");
            }

            var projectDto = new ProjectDto()
            {
                ProjId = Project.Id,
                Title = Project.Title,
                Description = Project.Description,
                CreatedAt = Project.CreatedAt,
                LeaderId = Project.LeaderId,
            };

            return BaseResponse<ProjectDto>.Ok(projectDto);

        }
    }
}
