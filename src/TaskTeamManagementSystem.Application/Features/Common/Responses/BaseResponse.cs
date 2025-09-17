using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Application.Features.Common.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public static BaseResponse Ok(string message = "") =>
            new BaseResponse { Success = true, Message = message };

        public static BaseResponse Fail(string message) =>
            new BaseResponse { Success = false, Message = message };
    }
}
