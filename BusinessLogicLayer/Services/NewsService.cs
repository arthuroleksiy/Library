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

    public class NewsService: INewsService
    {

        public IUnitOfWork UnitOfWork { get; }
        public NewsService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            UnitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Article> GetNews() {
            return  UnitOfWork.News.GetAllNews().AsEnumerable();
        }
        public IEnumerable<Article> GetNewsByOrder()
        {
            return UnitOfWork.News.GetAllNews().AsEnumerable().OrderBy(i => i.Title);
        }
        public IEnumerable<Article> GetNewsByDescending()
        {
            return UnitOfWork.News.GetAllNews().AsEnumerable().OrderByDescending(i => i.Title);
        }
        public IEnumerable<Article> GetNewsContainingTag(string tag)
        {
            return UnitOfWork.News.GetAllNews().AsEnumerable().Where(i => i.Tags.Select(k => k.TagName).Contains(tag));
        }
        public IEnumerable<Article> GetResultsForPage(IEnumerable<Article> articles, int CurrentPage, int pageSize)
        {
            return articles.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Article> FormattedDescription(IEnumerable<string> shortDescription, IEnumerable<Article> chosenNews)
        {

            foreach (var i in chosenNews)
            {
                foreach (var j in shortDescription)
                {
                    if (i.Description.Contains(j))
                        i.Description = j;
                }
            }

            return chosenNews;

        }
        public async Task<Article> GetById(int id)
        {
            return await UnitOfWork.News.GetByIdAsync(id);
        }
      

        public IEnumerable<string> GetShortDescription(IEnumerable<Article> articles, int CurrentPage, int pageSize)
        {
            var res = articles.Where(i => i.Description.Length > 200).Select(i => i.Description.Remove(200, i.Description.Length - 200));
            return res.Concat(articles.Where(i => i.Description.Length <= 200).Select(i => i.Description));
             
        }
        public int GetNewsCount()
        {
            return UnitOfWork.News.GetAllNews().Count();
        }

        public async Task AddTagNews(int newsId, string tagName)
        {
            var requestedTag = UnitOfWork.Tags.GetTagByName(tagName);

            var news = GetNews();
            var selectedArticle = news.Where(i => i.ArticleId == newsId).SingleOrDefault();
            if (requestedTag == null)
                requestedTag = new Tag { TagName = tagName };

                requestedTag.Articles = new List<Article>();
                requestedTag.Articles.Add(selectedArticle);
                await UnitOfWork.Tags.Add(requestedTag);
                await UnitOfWork.SaveAsync();
            

        }
    }
}
