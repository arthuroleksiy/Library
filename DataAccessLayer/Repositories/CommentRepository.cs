using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Comment repository class
    /// </summary>
    public class CommentRepository: ICommentRepository
    {
        /// <summary>
        /// Context property
        /// </summary>
        private LibraryDbContext db;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context">Context argument</param>
        public CommentRepository(LibraryDbContext context)
        {
            this.db = context;
        }
        /// <summary>
        /// Method gets enumerable of comments
        /// </summary>
        /// <returns>All comments</returns>
        public IEnumerable<Comment> GetAllComments()
        {
            return db.Comments;
        }

        /// <summary>
        /// Add comment to context
        /// </summary>
        /// <param name="comment">Comment that has to be added to context</param>
        public async Task AddComment(Comment comment)
        {
            await Task.Run(() =>
            {
                comment.CommentId = GetLastComment() + 1;
                db.Comments.Add(comment);
            });
        }
        /// <summary>
        /// Returns last comment id
        /// </summary>
        /// <returns>Last comment id</returns>
        public int GetLastComment()
        {
            Comment comment = db.Comments.OrderByDescending(o => o.CommentId).FirstOrDefault();
            if (comment is null)
                return 1;

            return comment.CommentId;
        }
    }
}