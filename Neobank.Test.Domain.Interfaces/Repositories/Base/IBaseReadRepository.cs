namespace Neobank.Test.Domain.Interfaces.Repositories.Base
{
    public interface IBaseReadRepository<TModel, TEntity>
    {
        public Task<IEnumerable<TModel>> GetAllAsync();
    }
}
