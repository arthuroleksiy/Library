using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IQuestionnaryService
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddResult(FormModel form);
        bool ContainsEmail(string email);
        IEnumerable<Article> GetResultsForPage(IEnumerable<Article> articles, int CurrentPage, int pageSize);
    }
}
