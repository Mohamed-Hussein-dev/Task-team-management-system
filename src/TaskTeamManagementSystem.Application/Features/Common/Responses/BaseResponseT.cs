using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Application.Features.Common.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public Object Errors { get; set; }
        public T? Data { get; set; }

        public static BaseResponse<T> Ok(T data, string message = "") =>
            new BaseResponse<T> { Success = true, Data = data, Message = message };

        public static BaseResponse<T> Fail(string message) =>
            new BaseResponse<T> { Success = false, Message = message};

        public static BaseResponse<T> Fail(string message , object eroros) =>
            new BaseResponse<T> { Success = false, Message = message  , Errors = eroros };
    }
}
