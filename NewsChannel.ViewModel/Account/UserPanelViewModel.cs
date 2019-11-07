using System.Collections.Generic;
using NewsChannel.DomainClasses.Identity;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewModel.Account
{
    public class UserPanelViewModel
    {
        public UserPanelViewModel(User user, List<NewsViewModel> bookmarks)
        {
            User = user;
            Bookmarks = bookmarks;
        }
        public User User { get; set; }
        public List<NewsViewModel> Bookmarks { get; set; }
    }
}
