namespace Neobank.Test.Domain.Interfaces.Repositories.Base
{
    public interface IBaseWriteRepository<TModel, TEntity>
    {
        public Task<TModel> CreateAsync(TModel model);
    }
}
