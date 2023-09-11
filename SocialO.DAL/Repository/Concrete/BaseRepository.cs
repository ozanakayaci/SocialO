using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialO.DAL.DBContexts;
using SocialO.DAL.Repository.Abstract;
using SocialO.Entities.Abstract;

namespace SocialO.DAL.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SqlDBContext dbContext;


        public BaseRepository()
        {

            this.dbContext = new SqlDBContext();
        }

        public virtual async Task<int> InsertAsync(T entity)
        {
            // Set metodu dbContex icerisndeki gelen T tipi ne ise ona konumlanir.
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T?> GetBy(Expression<Func<T, bool>> filter)
        {


            return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }


        public async Task<ICollection<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
            {
                return await dbContext.Set<T>().ToListAsync();
            }
            return await dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query;
            if (filter != null)
            {
                query = dbContext.Set<T>().Where(filter);
            }
            query = dbContext.Set<T>();

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }



    }
}