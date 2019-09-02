using System.Threading.Tasks;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DataLayer.Repositories;

namespace NewsChannel.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public NewsDbContext _Context { get; }
        private ICategoryRepository _categoryRepository;
        public UnitOfWork(NewsDbContext context)
        {
            _Context = context;
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> repository = new BaseRepository<TEntity, NewsDbContext>(_Context);
            return repository;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_Context);

                return _categoryRepository;
            }
        }
        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
