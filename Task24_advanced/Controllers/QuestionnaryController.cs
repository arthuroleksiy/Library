using System;
using System.Web.Mvc;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Task24_advanced.FIlters;

namespace PresentationLayer.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionnaryController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        IQuestionnaryService questionnaryService;

        /// <summary>
        /// 
        /// </summary>
        public QuestionnaryController(IQuestionnaryService questionnaryService)
        {
            this.questionnaryService = questionnaryService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MyActionAttribute]
        public ViewResult MakeForm()
        {
            return View(new FormModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [MyActionAttribute]
        public ViewResult MakeForm(FormModel form)
        {
            if (ModelState.IsValid)
            {
                questionnaryService.AddResult(form);
                return View("InputAnswers", form);
            }
            else
                return View();
        }

        [HttpGet]
        [MyActionAttribute]
        public JsonResult ValidateEmail(string Email)
        {
            if (questionnaryService.ContainsEmail(Email))
            {
               return Json("Please enter a date in the", JsonRequestBehavior.AllowGet);  
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}