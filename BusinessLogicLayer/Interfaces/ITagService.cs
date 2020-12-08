using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITagService
    {
        IUnitOfWork UnitOfWork { get; set; }
        Task AddTag(string tagName);
        Task<Tag> GetTagById(int id);
        Task<Tag> GetTagByName(string name);
        IEnumerable<Tag> GetTags();
        int GetLastId();
    }
}
