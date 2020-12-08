using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGuestRoomService
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddCommentAndGetNewList(Comment newComment);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetResultsForPage(IEnumerable<Comment> articles, int CurrentPage, int pageSize);
    }
}
