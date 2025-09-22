using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;
using TaskTeamManagementSystem.Application.Features.Projects.Commands.DTOs;
using TaskTeamManagementSystem.Application.Interfaces;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Application.Features.Projects.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseResponse<ProjectDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ProjectDto>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project()
            {
                Title = request.Dto.Title,
                Description = request.Dto.Description,
                LeaderId = request.LeaderId
            };

            await unitOfWork.Projects.AddAsync(project);

            var AddProjectRes = await unitOfWork.CommitChangesAsync();

            if(AddProjectRes == 0)
            {
                return BaseResponse<ProjectDto>.Fail("Create Project Failed");
            }
            var projectDto = new ProjectDto()
            {
                ProjId = project.Id,
                Title = request.Dto.Title,
                Description = request.Dto.Description,
                LeaderId = project.LeaderId
            };
            return BaseResponse<ProjectDto>.Ok(projectDto , "Project Created Successfully");
        }
    }
}
