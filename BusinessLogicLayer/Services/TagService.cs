using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TagService: ITagService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public TagService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            UnitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }
        public Task AddTag(string tagName)
        {
            Tag tag = new Tag { TagName = tagName };

            return Task.Run(async () =>
            {
                await UnitOfWork.Tags.Add(tag);
                UnitOfWork.Save();
            });
        }

        public Task<Tag> GetTagById(int id)
        {
            return Task.Run(() => UnitOfWork.Tags.GetTagById(id));
        }
        public Task<Tag> GetTagByName(string name)
        {
            return Task.Run(() => UnitOfWork.Tags.GetTagByName(name));
        }
        public int GetLastId()
        {
            return Task.Run(() => UnitOfWork.Tags.GetLastId()).Result;
        }
        public IEnumerable<Tag> GetTags()
        {
            return UnitOfWork.Tags.GetAll();
        }
    }
}
