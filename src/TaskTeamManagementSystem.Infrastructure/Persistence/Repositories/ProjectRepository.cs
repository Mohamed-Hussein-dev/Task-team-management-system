using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project, int> , IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
