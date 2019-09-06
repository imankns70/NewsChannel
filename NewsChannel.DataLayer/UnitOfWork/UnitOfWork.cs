using System.Threading.Tasks;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DataLayer.Repositories;

namespace NewsChannel.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public NewsDbContext _Context { get; }
        private ICategoryRepository _categoryRepository;
        private ITagRepository _tagRepository;
        private IVideoRepository _videoRepository;
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
        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_Context);

                return _tagRepository;
            }
        }


        public IVideoRepository VideoRepository
        {
            get
            {
                if (_videoRepository == null)
                    _videoRepository = new VideoRepository(_Context);

                return _videoRepository;
            }
        }
        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
