using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Newsletter;

namespace NewsChannel.DataLayer.Contracts
{
    public interface INewsletterRepository
    {
        List<NewsletterViewModel> GetPaginateNewsletter(int offset, int limit, Func<NewsletterViewModel, Object> orderByAscFunc, Func<NewsletterViewModel, Object> orderByDescFunc, string searchText);
        Task<NewsLetter> FindNewsLetterByEmail(string email);
    }
}
