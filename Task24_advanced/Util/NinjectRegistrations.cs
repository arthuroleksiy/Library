using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task24_advanced.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IGuestRoomService>().To<GuestRoomService>();
            Bind<IQuestionnaryService>().To<QuestionnaryService>();
            Bind<INewsService>().To<NewsService>();
            Bind<ITagService>().To<TagService>();
        }
    }
}