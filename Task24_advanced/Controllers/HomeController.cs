using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.SqlServer.Server;
using PagedList;
using Task24_advanced.FIlters;
using Task24_advanced.ViewModels;

namespace PresentationLayer.Controllers
{
    /// <summary>
    /// Main page controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Unit of work pattern field
        /// </summary>
        INewsService HomeService { get; }
        ITagService TagService { get; }
        int pageSize = 3;
        int CurrentPage { get; set; }
        HttpCookie userInfo;
        HttpCookie pageNumber;
        IEnumerable<Article> NewsPerPage;

        PageViewModel pageInfo;
        HomeViewModel ivm;
        IEnumerable<Article> chosenNews = new List<Article>();
        /// <summary>
        /// Class constructor
        /// </summary>
        public HomeController(INewsService homeService, ITagService TagService)
        {
            this.HomeService = homeService;
            this.TagService = TagService;
            userInfo = new HttpCookie("userInfo");
            pageNumber = new HttpCookie("pageNumber");
            //pageNumber["page"] = "1";

        }
        /// <summary>
        /// Method returns news collection to the news
        /// </summary>
        /// <returns>News collection</returns>
        [MyActionAttribute]
        public ActionResult Index(int page = 1)
        {
            CurrentPage = page;
            pageNumber["page"] = page.ToString();
            if (!String.IsNullOrEmpty(Response.Cookies["sorting"].Value))
            {
                if (Response.Cookies["sorting"].Value.Equals("Ascending"))
                {
                    NewsPerPage = HomeService.GetNewsByOrder();
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }
                else if (Response.Cookies["sorting"].Value.Equals("Descending"))
                {
                    NewsPerPage = HomeService.GetNewsByDescending();
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }
                else
                {
                    NewsPerPage = HomeService.GetNewsContainingTag(Response.Cookies["sorting"].Value);
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }
            }
            else
            {

                userInfo["sorting"] = "Normal";
                NewsPerPage = HomeService.GetNews();
                chosenNews = HomeService.GetResultsForPage(NewsPerPage, page, pageSize);
            }

            var shortDescription = HomeService.GetShortDescription(NewsPerPage, CurrentPage, pageSize);
            chosenNews = HomeService.FormattedDescription(shortDescription, chosenNews);

            PageViewModel pageInfo = new PageViewModel { PageNumber = page, PageSize = pageSize, TotalItems = NewsPerPage.Count() };
            HomeViewModel ivm = new HomeViewModel { News = chosenNews, PageViewModel = pageInfo };
            return View(ivm);
        }

        [HttpPost]
        [MyActionAttribute]
        public async Task<ActionResult> Index(string id, string tag)
        {
            int page;

            if(!Int32.TryParse(Response.Cookies["page"].Value, out int pageResult))
            {
                page = 1;
            } 
            else
            {
                page = pageResult;
            }

            NewsPerPage = HomeService.GetNews();
            chosenNews = HomeService.GetResultsForPage(NewsPerPage, page, pageSize);

            if (String.IsNullOrEmpty(tag) )
            {
                PageViewModel pageInfo = new PageViewModel { PageNumber = page, PageSize = pageSize, TotalItems = HomeService.GetNewsCount() };
                HomeViewModel ivm = new HomeViewModel { News = NewsPerPage, PageViewModel = pageInfo };

                ModelState.AddModelError(tag, "Tag is empty");
                return View();
            }
            else
            {

                await HomeService.AddTagNews(Int32.Parse(id), tag);

                NewsPerPage = HomeService.GetResultsForPage(NewsPerPage, page, pageSize);

                var shortDescription = HomeService.GetShortDescription(NewsPerPage, page, pageSize); //for (int i = 0; i < NewsPerPage.Count(); i++)
                

                NewsPerPage = HomeService.FormattedDescription(shortDescription, NewsPerPage);
                PageViewModel pageInfo = new PageViewModel { PageNumber = page, PageSize = pageSize, TotalItems = HomeService.GetNewsCount() };
                HomeViewModel ivm = new HomeViewModel { News = NewsPerPage, PageViewModel = pageInfo };


                Debugger.NotifyOfCrossThreadDependency();
                return View(ivm);
            }
        }

        [ActionName("ActionByGenre")]
        [MyActionAttribute]
        public ActionResult Index(string genreTag)
        {
            if (String.IsNullOrEmpty(genreTag))
            {
                NewsPerPage = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                PageViewModel pageInfo = new PageViewModel { PageNumber = CurrentPage, PageSize = pageSize, TotalItems = HomeService.GetNewsCount() };
                HomeViewModel ivm = new HomeViewModel { News = NewsPerPage, PageViewModel = pageInfo };

                ModelState.AddModelError(genreTag, "Tag is empty");
                return View("Index");
            }
            else
            {
                userInfo["sorting"] = genreTag;
                Response.Cookies.Add(userInfo);
                if(genreTag.Equals("Normal"))
                {

                    CurrentPage = 1;
                    NewsPerPage = HomeService.GetNews();
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }
                else if (genreTag.Equals("Ascending"))
                {
                    CurrentPage = 1;
                    NewsPerPage = HomeService.GetNewsByOrder();
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);


                } 
                else if (genreTag.Equals("Descending"))
                {
                    CurrentPage = 1;
                    NewsPerPage = HomeService.GetNewsByDescending();
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }
                else {

                    CurrentPage = 1;
                    NewsPerPage = HomeService.GetNewsContainingTag(genreTag);
                    chosenNews = HomeService.GetResultsForPage(NewsPerPage, CurrentPage, pageSize);
                }

                var shortDescription = HomeService.GetShortDescription(NewsPerPage, CurrentPage, pageSize);

                chosenNews = HomeService.FormattedDescription(shortDescription, chosenNews);
                
                pageInfo = new PageViewModel { PageNumber = CurrentPage, PageSize = pageSize, TotalItems = NewsPerPage.Count() };
                ivm = new HomeViewModel { News = chosenNews, PageViewModel = pageInfo };


                Debugger.NotifyOfCrossThreadDependency();
                return View("Index", ivm);
            }
        }

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        [ActionName("FirstIndex")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult DetailArticle()
        {
            return View();
        }

    }
}   