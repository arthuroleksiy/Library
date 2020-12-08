using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class QuestionnaryService: IQuestionnaryService
    {
        public IUnitOfWork UnitOfWork { get; }

        public QuestionnaryService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            UnitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }
        public Task AddResult(FormModel form)
        {
            return Task.Run(() =>
            {
                UnitOfWork.Forms.AddForm(form);
                UnitOfWork.Save();
            });
        }

        public IEnumerable<Article> GetResultsForPage(IEnumerable<Article> articles, int CurrentPage, int pageSize)
        {
            return articles.Skip((CurrentPage - 1) * pageSize).Take(pageSize);
        }

        public bool ContainsEmail(string email)
        {
            return UnitOfWork.Forms.GetAllForms().Select(i => i.Email).Contains(email);
        }

    }
}
