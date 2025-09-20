using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<ProjectTask, int> , ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
