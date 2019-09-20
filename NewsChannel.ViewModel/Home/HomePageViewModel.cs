using System.Collections.Generic;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewModel.Home
{
    public class HomePageViewModel
    {
        public HomePageViewModel(List<NewsViewModel> news)
        {
            News = news;
        }

        public List<NewsViewModel> News { get; set; }
    }
}