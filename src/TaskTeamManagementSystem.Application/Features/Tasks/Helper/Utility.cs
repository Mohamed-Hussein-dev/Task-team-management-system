using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Application.Features.Tasks.Helper
{
    public static class Utility
    {
       public static string getType(int type)
        {
            return type switch
            {
                0 => "Task",
                1 => "Bug",
                2 => "Feature"
            };
            // 0 - Task , 1 - Bug , 2 - Feature 
        }

       public static int? getStatus(string status)
        {
            // 0 - NotStarted , 1 - InProgress , 2 - Done
            return status switch
            {
                "NotStarted" => 0,
                "InProgress" => 1,
                "Done" => 2,
                _ => null

            };
        }

        public static string ? getStatus(int status)
        {
            return status switch
            {
                0 => "NotStarted",
                1 => "InProgress",
                2 => "Done",
                _ => null
            };
        }
       public static int? getType(string type)
        {
            return type switch
            {
                "Task" => 0,
                "Bug" => 1,
                "Feature" => 2,
                _ => null
            };
            // 0 - Task , 1 - Bug , 2 - Feature 

        }

    }
}
