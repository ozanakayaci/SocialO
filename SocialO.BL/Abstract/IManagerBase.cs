using System.Linq.Expressions;
using SocialO.Entities.Abstract;

namespace SocialO.BL.Abstract
{
    public interface IManagerBase<T> where T : BaseEntity
    {
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetBy(Expression<Func<T, bool>> filter);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include);
    }
}