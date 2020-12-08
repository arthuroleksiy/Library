using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface INewsService
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<Article> GetNews();
        Task AddTagNews(int newsId, string tagName);
        IEnumerable<Article> GetNewsByOrder();
        IEnumerable<Article> GetNewsByDescending();
        IEnumerable<Article> GetNewsContainingTag(string tag);
        int GetNewsCount();
        Task<Article> GetById(int id);
        IEnumerable<Article> FormattedDescription(IEnumerable<string> shortDescription, IEnumerable<Article> chosenNews);
        IEnumerable<Article> GetResultsForPage(IEnumerable<Article> articles, int CurrentPage, int pageSize);
        IEnumerable<string> GetShortDescription(IEnumerable<Article> articles, int CurrentPage, int pageSize);
    }
}
