using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TagRepository: ITagRepository
    {
        private LibraryDbContext db;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Context argument</param>
        public TagRepository(LibraryDbContext context)
        {
            this.db = context;
        }

        public Task Add(Tag tag)
        {
            return Task.Run(() => db.Tags.Add(tag));
        }

        public IQueryable<Tag> GetAll()
        {
            return db.Tags;
        }

        public Task<Tag> GetTagById(int id)
        {
            return Task.Run(() =>
            {
                return db.Tags.Find(id);
            });
        }

        public Tag GetTagByName(string name)
        {
            return db.Tags.Where(i => i.TagName == name).FirstOrDefault();
        }
        public Task<Tag> GetTagByNameWithDetails(string name)
        {
            return Task.Run(() =>
            {
                var result = db.Tags.Where(i => i.TagName == name).First();
                db.Entry(result).Collection(p => p.Articles).Load();
                return result;
            });
        }

        public int GetLastId()
        {
            return db.Tags.Max(x => x.TagId);
        }
    }
}
