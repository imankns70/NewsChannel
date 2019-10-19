﻿using System.Threading.Tasks;

namespace NewsChannel.DataLayer.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        IVideoRepository VideoRepository { get; }
        INewsRepository NewsRepository { get; }
        INewsletterRepository NewsletterRepository { get; }
        NewsDbContext _Context { get; }
        Task Commit();
    }
}
