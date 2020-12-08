using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task24_advanced.ViewModels;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.WebSockets;
using Task24_advanced.FIlters;

namespace PresentationLayer.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GuestRoomController : Controller
    {
        IGuestRoomService guestRoomService;
        GuestRoomViewModel guestRoomViewModel = new GuestRoomViewModel();
        int pageSize = 3;
        int Page { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        public GuestRoomController(IGuestRoomService guestRoomService)
        {
            this.guestRoomService = guestRoomService;
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MyActionAttribute]
        public ActionResult ReviewInput(int page = 1)
        {
            Page = page;
            var guestRoomData = new List<GuestRoomDataViewModel>();
            var comments = guestRoomService.GetComments();
            var resultForPage = guestRoomService.GetResultsForPage(comments, Page, pageSize);

            foreach (var i in resultForPage) {
                guestRoomData.Add(new GuestRoomDataViewModel { CommentId = i.CommentId, Author = i.Author, Date = String.Format("{0:dd/MM/yyyy}", i.Date), Description = i.Description });
            }

            PageViewModel paginationViewModel = new PageViewModel { PageNumber = page, PageSize = pageSize, TotalItems = comments.Count() };
            guestRoomViewModel = new GuestRoomViewModel
            {
                GuestRoomData = guestRoomData,
                PaginationViewModel = paginationViewModel,
                NewData = null
            };
            ViewBag.Page = page;
            TempData["Page"] = page;
           
            return View("ReviewInput", guestRoomViewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [MyActionAttribute]
        [HttpPost]
        public async Task<ActionResult> ReviewInput(GuestRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestRoomData = new List<GuestRoomDataViewModel>();
                int page = Page;
                Comment newComment = new Comment { Author = model.NewData.Author, Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Description = model.NewData.Description };

                await guestRoomService.AddCommentAndGetNewList(newComment);
                var result = guestRoomService.GetComments();
                var resultForPage = guestRoomService.GetResultsForPage(result, Page, pageSize);
                foreach (var i in resultForPage)
                {
                    guestRoomData.Add(new GuestRoomDataViewModel { CommentId = i.CommentId, Author = i.Author, Date = String.Format("{0:dd/MM/yyyy}", i.Date), Description = i.Description });
                }

                PageViewModel paginationViewModel = new PageViewModel { PageNumber = page, PageSize = pageSize, TotalItems = result.Count() };
                guestRoomViewModel = new GuestRoomViewModel
                {
                    GuestRoomData = guestRoomData,
                    PaginationViewModel = paginationViewModel,
                    NewData = null
                };

                return View("ReviewInput", guestRoomViewModel);

            }
            else
            {
                return View();
            }
        }
    }
}
