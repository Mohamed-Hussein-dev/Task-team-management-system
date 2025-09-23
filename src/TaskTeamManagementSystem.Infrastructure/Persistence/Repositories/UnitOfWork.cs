using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Interfaces;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(ApplicationDbContext dbContext , IServiceProvider serviceProvider)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
        }
        public IProjectRepository Projects => serviceProvider.GetRequiredService<IProjectRepository>();

        public ITaskRepository Tasks => serviceProvider.GetRequiredService<ITaskRepository>();

        public async Task<int> CommitChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }
    }
}
