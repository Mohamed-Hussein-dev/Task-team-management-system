using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Domain.Entities.Identtity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public ICollection<Project> LeadingProjects { get; set; } = new List<Project>();
        public ICollection<Project> ProjectMemberships { get; set; } = new List<Project>();
    }
}
