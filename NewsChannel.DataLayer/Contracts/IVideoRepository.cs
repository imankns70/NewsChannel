using System.Collections.Generic;
using System.Threading.Tasks;
using NewsChannel.ViewModel.Video;

namespace NewsChannel.DataLayer.Contracts
{
    public interface IVideoRepository
    {
        string CheckVideoFileName(string fileName);
        Task<List<VideoViewModel>> GetPaginateVideosAsync(int offset, int limit, bool? titleSortAsc, bool? publishDateTimeSortAsc, string searchText);
    }
}
