using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BVL.Models;

namespace BVL.Controllers
{
    public class MyController : Controller
    {
        private string lang;
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LanguageMang.GetDefaultLanguage();
                }
            }
            new LanguageMang().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }
        public string mylanguage { get { return lang; } }
        }
}