using System;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Identity;
using DataAccessLayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        LibraryDbContext db = new LibraryDbContext();
        /// <summary>
        /// 
        /// </summary>
        private NewsRepository newsRepository;
        /// <summary>
        /// 
        /// </summary>
        private CommentRepository commentRepository;
        /// <summary>
        /// 
        /// </summary>
        private FormRepository formRepository;
        /// <summary>
        /// 
        /// </summary>
        private TagRepository tagRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public ApplicationUserManager UserManager
        {
            get {

                if (userManager == null)
                    userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                return userManager; }
        }

        public IClientManager ClientManager
        {
            get {

                if (clientManager == null)
                    clientManager = new ClientManager(db);
                return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get {

                if (roleManager == null)
                    roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
                return roleManager; 
            }
        }

        public INewsRepository News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommentRepository Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IFormRepository Forms
        {
            get
            {
                if (formRepository == null)
                    formRepository = new FormRepository(db);
                return formRepository;
            }
        }
        public ITagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Task.Run(() => db.SaveChangesAsync());

        }

    }
}