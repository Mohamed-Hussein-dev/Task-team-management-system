using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Application.Interfaces.Repositories
{
    public interface IProjectRepository : IGenericRepository<Project , int>
    {
    }
}
