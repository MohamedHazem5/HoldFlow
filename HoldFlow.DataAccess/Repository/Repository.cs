using Microsoft.EntityFrameworkCore;

namespace HoldFlow.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
            _dbContext = context;

        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            _dbContext.SaveChanges();

            return entities;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();

            return entities;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public IEnumerable<T> DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _dbContext.SaveChanges();

            return entities;
        }

        public async Task<IEnumerable<T>> GetBySpecification(Specification<T> specification)
        {
            var entities = specification.Criteria != null ? _dbSet.Where(specification.Criteria) : _dbSet;

            if (specification.IncludeProperties != null)
                entities = specification.IncludeProperties.Aggregate(entities, (record, property) => record.Include(property));

            if (specification.OrderBy != null)
                entities = entities.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                entities = entities.OrderByDescending(specification.OrderByDescending);

            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = filter != null ? _dbSet.Where(filter) : _dbSet;

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (record, property) => record.Include(property));
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllNoTrackingAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = filter != null ? _dbSet.Where(filter).AsNoTracking() : _dbSet;

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (record, property) => record.Include(property).AsNoTracking());
            return await query.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = filter != null ? _dbSet.Where(filter) : _dbSet;

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (record, property) => record.Include(property));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            return await (filter != null ? _dbSet.CountAsync(filter) : _dbSet.CountAsync());
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await (filter != null ? _dbSet.AnyAsync(filter) : _dbSet.AnyAsync());
        }


    }
}