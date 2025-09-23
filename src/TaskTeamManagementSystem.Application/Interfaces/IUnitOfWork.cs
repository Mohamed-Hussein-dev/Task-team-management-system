using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProjectRepository Projects { get; }
        ITaskRepository Tasks { get; }
        Task<int> CommitChangesAsync();
    }
}
