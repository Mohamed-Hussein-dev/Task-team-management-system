using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Commands
{
    public class AssignTaskCommand : IRequest<BaseResponse<bool>>
    {
        public string UserEmail { get; set; }
        public int TaskId { get; set; }
        public AssignTaskCommand(string userEmail , int taskId) {
            UserEmail = userEmail;
            TaskId = taskId;
        }
    }
}
