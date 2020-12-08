using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITagRepository
    {
        Task Add(Tag tag);
        IQueryable<Tag> GetAll();
        int GetLastId();
        Task<Tag> GetTagById(int id);
        Tag GetTagByName(string name);
        Task<Tag> GetTagByNameWithDetails(string name);
    }
}
