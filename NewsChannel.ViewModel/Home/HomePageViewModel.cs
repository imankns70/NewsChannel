using System.Collections.Generic;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewModel.Home
{
    public class HomePageViewModel
    {
        public HomePageViewModel(List<NewsViewModel> news, List<NewsViewModel> mostViewedNews,
            List<NewsViewModel> mostTalkNews, List<NewsViewModel> mostPopularNews)
        {
            News = news;
            MostViewedNews = mostViewedNews;
            MostTalkNews = mostTalkNews;
            MostPopularNews = mostPopularNews;
        }

        public List<NewsViewModel> News { get; set; }
        public List<NewsViewModel> MostViewedNews { get; set; }
        public List<NewsViewModel> MostTalkNews { get; set; }
        public List<NewsViewModel> MostPopularNews { get; set; }
    }
}