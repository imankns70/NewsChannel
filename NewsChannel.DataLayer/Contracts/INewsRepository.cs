using NewsChannel.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
