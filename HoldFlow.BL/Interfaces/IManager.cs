namespace HoldFlow.BL.Interfaces
{
    public interface IManager<T> where T : class
    {
        Task<T> AddAsync(T entity);

        T Update(T entity);

        T Delete(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
    }
}