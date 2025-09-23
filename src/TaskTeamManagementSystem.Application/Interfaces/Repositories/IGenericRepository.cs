using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Application.Interfaces.Repositories
{
    public interface IGenericRepository <TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task AddAsync(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
