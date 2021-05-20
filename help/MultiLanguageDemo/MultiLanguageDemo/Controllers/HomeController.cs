using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MultiLanguageDemo.Models;
using MultiLanguageDemo.Content.Texts;

namespace MultiLanguageDemo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = RHome.About;
            ViewBag.Message = RHome.AboutMessage;
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Title = RHome.Contact;
            ViewBag.Message = RHome.ContactMessage;
            ViewBag.ContactResult = TempData["ContactResult"];
            ViewBag.ContactResultMessage = TempData["ContactResultMessage"] ?? "";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            ViewBag.Title = RHome.Contact;
            ViewBag.Message = RHome.ContactMessage;
            if (ModelState.IsValid)
            {
                /* Do something with this information */
                TempData["ContactResult"] = true;
                TempData["ContactResultMessage"] = RHome.ContactMessageSendOk;
                return RedirectToAction("Contact"); /* Post-Redirect-Get Pattern */
            }
            ViewBag.ContactResult = false;
            ViewBag.ContactResultMessage = RHome.ContactMessageSendNok;
            return View(model);
        }
    }
}