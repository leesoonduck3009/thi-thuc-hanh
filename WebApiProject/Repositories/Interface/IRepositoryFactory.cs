using TestWebApplication.Entities;

namespace TestWebApplication.Repositories.Interface
{
    public interface IRepositoryFactory
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
