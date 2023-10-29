using SocialO.DAL.DBContexts;
using System.Linq.Expressions;

namespace SocialO.DAL.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        public SqlDBContext dbContext { get; set; }
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