namespace HoldFlow.BL.Managers
{
    public class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _repository.Delete(entity);
            return entity;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var result = _repository.FirstOrDefaultAsync(filter, includeProperties);
            return await result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var result = _repository.GetAllAsync(filter, includeProperties);
            return await result;
        }

        public T Update(T entity)
        {
            _repository.Update(entity);
            return entity;
        }
    }
}