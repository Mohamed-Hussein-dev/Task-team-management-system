using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Domain.Entities
{
    public class Project : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? LeaderId { get; set; }
        public AppUser? Leader { get; set; }
        public ICollection<AppUser> Memebers { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
