using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Newsletter;

namespace NewsChannel.DataLayer.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {

        private readonly NewsDbContext _context;
        public NewsletterRepository(NewsDbContext context)
        {
            _context = context;
        }


        public List<NewsletterViewModel> GetPaginateNewsletter(int offset, int limit, Func<NewsletterViewModel, Object> orderByAscFunc, Func<NewsletterViewModel, Object> orderByDescFunc, string searchText)
        {
            List<NewsletterViewModel> newsletter = _context.NewsLetters.Where(c => c.Email.Contains(searchText) || c.RegisterDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت hh:mm:ss").Contains(searchText))
                .Select(l => new NewsletterViewModel { Id = l.Id, Email = l.Email,IsActive=l.IsActive, PersianRegisterDateTime = l.RegisterDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت hh:mm:ss") }).AsEnumerable()
                                   .OrderBy(orderByAscFunc).ThenByDescending(orderByDescFunc)
                                   .Skip(offset).Take(limit).ToList();

            foreach (var item in newsletter)
                item.Row = ++offset;

            return newsletter;
        }

        public async Task<NewsLetter> FindNewsLetterByEmail(string email)
        {
            return await _context.NewsLetters.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
