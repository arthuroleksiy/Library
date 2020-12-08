using DataAccessLayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// 
        /// </summary>
        public LibraryDbContext() : base("DefaultConnection")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Article> Articles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Comment> Comments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<FormModel> FormModels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        //public DbSet<TagArticle> TagArticles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                   .HasMany(b => b.Tags)
                   .WithMany(c => c.Articles);

            modelBuilder.Entity<Tag>()
                   .HasMany(b => b.Articles)
                   .WithMany(c => c.Tags);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}