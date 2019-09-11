using NewsChannel.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsChannel.ViewModel.News;

namespace NewsChannel.DataLayer.Contracts
{
    public interface INewsRepository
    {
        string CheckNewsFileName(string fileName);
        Task<List<NewsViewModel>> GetPaginateNewsAsync(int offset, int limit, bool? titleSortAsc, bool? visitSortAsc, bool? likeSortAsc, bool? dislikeSortAsc, bool? publishDateTimeSortAsc, string searchText);
    }
}
