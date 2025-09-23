using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Application.Interfaces.Repositories;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity item) => await dbSet.AddAsync(item);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            dbSet.Update(item);
        }
    }
}
