using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Task24_advanced.Controllers
{
    public class DetailedArticleController : Controller
    {

        INewsService HomeService { get; }
        int pageSize = 3;
        int CurrentPage { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public DetailedArticleController(INewsService homeService)
        {
            this.HomeService = homeService;
        }
        
        public async Task<ViewResult> Index(int id)
        {
            var home = await HomeService.GetById(id);

            return View(home);
        }
    }
}