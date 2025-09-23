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
    public class GetUserProjectsHandler : IRequestHandler<GetUserProjectsQuery, BaseResponse<List<ProjectDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserProjectsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<ProjectDto>>> Handle(GetUserProjectsQuery request, CancellationToken cancellationToken)
        {
            var Projects = await unitOfWork.Projects.GetAllAsync(project => project.LeaderId == request.UserId || project.Memebers.Any(user => user.Id == request.UserId));
            
            List<ProjectDto> result = new List<ProjectDto>();
            foreach (var project in Projects) {

                result.Add(new ProjectDto() {
                    Title = project.Title,
                    Description = project.Description,
                    LeaderId = project.LeaderId,
                    CreatedAt = project.CreatedAt,
                    ProjId = project.Id,
                });
            }
            return BaseResponse<List<ProjectDto>>.Ok(result);
        }
    }
}
