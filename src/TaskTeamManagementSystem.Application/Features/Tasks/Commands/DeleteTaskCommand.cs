using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Features.Common.Responses;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<BaseResponse<bool>>
    {
        public int TaskId { get; set; }
        public DeleteTaskCommand(int taskId){
            TaskId = taskId;
        }
    }
}
