using System.Linq.Expressions;

namespace Domain.Repositories.Interfaces; 

public interface IRepository<TEntity> where TEntity:class {
    
    Task CreateAsync(TEntity entity);
    
    Task UpdateAsync(TEntity entity);
    
    Task<TEntity?> ReadAsync(int id);
    
    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);
    
    Task<List<TEntity>> ReadAllAsync(int start, int count);

}