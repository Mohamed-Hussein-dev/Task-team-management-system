using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Domain.Entities
{
    public class ProjectTask : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Status { get; set; } = 0;// 0 - NotStarted , 1 - InProgress , 2 - Done
        public int Type { get; set; } = 0; // 0 - Task , 1 - Bug , 2 - Feature 
        public int ProjId { get; set; }
        public string? AssigneeUserId { get; set; }
        public AppUser?  AssigneeUser { get; set; }
        public Project Project { get; set; }

    }
}
