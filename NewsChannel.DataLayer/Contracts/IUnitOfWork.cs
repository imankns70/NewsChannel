using System.Threading.Tasks;

namespace NewsChannel.DataLayer.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        ICategoryRepository CategoryRepository { get; }
        NewsDbContext _Context { get; }
        Task Commit();
    }
}
