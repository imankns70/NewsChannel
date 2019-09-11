using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Tag;

namespace NewsChannel.DataLayer.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NewsDbContext _context;
        public TagRepository(NewsDbContext context)
        {
            _context = context;
        }


        public async Task<List<TagViewModel>> GetPaginateTagsAsync(int offset, int limit, bool? tagNameSortAsc, string searchText)
        {
            List<TagViewModel> tags = await _context.Tags.Where(c => c.TagName.Contains(searchText))
                                   .Select(t => new TagViewModel { TagId = t.Id, TagName = t.TagName }).Skip(offset).Take(limit).AsNoTracking().ToListAsync();

            if (tagNameSortAsc != null)
                tags = tags.OrderBy(c => (tagNameSortAsc == true) ? c.TagName : "").ThenByDescending(c => (tagNameSortAsc == false && tagNameSortAsc != null) ? c.TagName : "").ToList();

            foreach (var item in tags)
                item.Row = ++offset;

            return tags;
        }

        public bool IsExistTag(string tagName, int? recentTagId)
        {
            if (recentTagId == null)
                return _context.Tags.Any(c => c.TagName.Trim().Replace(" ", "") == tagName.Trim().Replace(" ", ""));
            else
            {
                var tag = _context.Tags.FirstOrDefault(c => c.TagName.Trim().Replace(" ", "") == tagName.Trim().Replace(" ", ""));
                if (tag == null)
                    return false;
                else
                {
                    if (tag.Id != recentTagId)
                        return true;
                    else
                        return false;
                }
            }
        }


        public async Task<List<NewsTag>> InsertNewsTags(string[] tags, int? newsId)
        {
           
            List<NewsTag> newsTags = new List<NewsTag>();
            var allTags = _context.Tags.ToList();
            if (newsId != null)
            {
                newsTags.AddRange(allTags.Where(n => tags.Contains(n.TagName))
                    .Select(c => new NewsTag
                        {
                            TagId = c.Id,
                            NewsId = newsId.Value
                        }).ToList());


                var newTags = tags.Where(n => !allTags.Select(t => t.TagName).Contains(n)).ToList();
                foreach (var item in newTags)
                {

                    _context.Tags.Add(new Tag { TagName = item });
                    var lastTag=_context.Tags.OrderByDescending(x => x.Id).First();
                    newsTags.Add(new NewsTag { TagId = lastTag.Id, NewsId = newsId.Value });
                    await _context.SaveChangesAsync();

                }
            }
            return newsTags;
        }
    }
}
