using System.Collections.Generic;
using System.Threading.Tasks;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Tag;

namespace NewsChannel.DataLayer.Contracts
{
    public interface ITagRepository
    {
        Task<List<TagViewModel>> GetPaginateTagsAsync(int offset, int limit, bool? tagNameSortAsc, string searchText);
        bool IsExistTag(string tagName, int? recentTagId);
        Task<List<NewsTag>> InsertNewsTags(string[] tags, int? newsId);
    }
}
