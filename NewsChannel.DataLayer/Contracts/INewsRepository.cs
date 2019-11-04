using NewsChannel.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsChannel.DomainClasses.Business;

namespace NewsChannel.DataLayer.Contracts
{
    public interface INewsRepository
    {
        int CountNewsPublished();
        string CheckNewsFileName(string fileName);
        List<NewsViewModel> GetPaginateNews(int offset, int limit, Func<IGrouping<int?, NewsViewModel>, object> orderByAscFunc, Func<IGrouping<int?, NewsViewModel>, object> orderByDescFunc, string searchText, bool? isPublish, bool? isInternal);
        Task<List<NewsViewModel>> MostViewedNews(int offset, int limit, string duration);
        Task<List<NewsViewModel>> MostTalkNews(int offset, int limit, string duration);
        Task<List<NewsViewModel>> MostPopularNews(int offset, int limit);
        Task<NewsViewModel> GetNewsById(int newsId);
        Task BindSubComments(Comment comment);
        Task<List<NewsViewModel>> GetNextAndPreviousNews(DateTime? publishDateTime);
        Task<List<NewsViewModel>> GetRelatedNews(int number, List<int?> tagIdList, int newsId);
        Task<List<Comment>> GetNewsCommentsAsync(int newsId);
    }
}
