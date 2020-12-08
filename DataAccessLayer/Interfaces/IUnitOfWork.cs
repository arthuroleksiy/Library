using DataAccessLayer.Identity;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        INewsRepository News { get;  }
        ICommentRepository Comments { get; }
        IFormRepository Forms { get; }
        ITagRepository Tags { get; }
        Task<int> SaveAsync(); 
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        void Save();
    }
}
