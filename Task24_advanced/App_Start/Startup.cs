using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using DataAccessLayer;

[assembly: OwinStartup(typeof(Task24_advanced.App_Start.Startup))]
namespace Task24_advanced.App_Start
{
    public class Startup
    {
        ServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
           // app.CreatePerOwinContext(UnitOfWork.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService();
        }
    }
}