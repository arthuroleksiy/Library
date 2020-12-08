using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class GuestRoomService: IGuestRoomService
    {
        public IUnitOfWork UnitOfWork { get; }

        public GuestRoomService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            UnitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }

        public async Task AddCommentAndGetNewList(Comment newComment)
        {
            await UnitOfWork.Comments.AddComment(newComment);
            await UnitOfWork.SaveAsync();
        }
        public IEnumerable<Comment> GetComments() {
              return UnitOfWork.Comments.GetAllComments();
        }

        public IEnumerable<Comment> GetResultsForPage(IEnumerable<Comment> articles, int CurrentPage, int pageSize)
        {
            return articles.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
