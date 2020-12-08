using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsRepository: INewsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private LibraryDbContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public NewsRepository(LibraryDbContext context)
        {
            this.db = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<Article> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                var r = db.Articles.Include(i => i.Tags);
                return r.Where(i => i.ArticleId == id).Select(i => i).First();
            });
        }

        public IQueryable<Article> GetAllNews()
        {
            var r = db.Articles.Include(i => i.Tags);

            return r;
        }

    }
}