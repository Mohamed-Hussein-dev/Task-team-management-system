using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Application.Features.Projects.Commands.DTOs
{
    public class ProjectDto
    {
        public int ProjId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LeaderId { get; set; }
    }
}
