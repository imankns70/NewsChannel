using System.Collections.Generic;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewModel.Home
{
    public class NewsDetailsViewModel
    {
        public NewsDetailsViewModel(NewsViewModel news, List<Comment> comments, List<NewsViewModel> newsRelated, List<NewsViewModel> nextAndPreviousNews)
        {
            News = news;
            Comments = comments;
            NewsRelated = newsRelated;
            NextAndPreviousNews = nextAndPreviousNews;
        }
        public NewsViewModel News { get; set; }
        public List<Comment> Comments { get; set; }
        public List<NewsViewModel> NewsRelated { get; set; }
        public List<NewsViewModel> NextAndPreviousNews { get; set; }
    }
}
