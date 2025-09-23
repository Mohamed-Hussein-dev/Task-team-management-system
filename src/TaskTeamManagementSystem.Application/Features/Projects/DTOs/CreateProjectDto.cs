using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamManagementSystem.Application.Features.Projects.DTOs
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
