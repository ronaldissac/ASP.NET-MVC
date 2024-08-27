using CustomerPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast;

namespace CustomerPortal.Controllers
{
    [Authorize]
    [SessionValidation]
        public class PageLoadController : Controller
        {
            // GET: PageLoad
            //public ActionResult LoadPage(string PageName)
            //{
            //    string aspxPagePath = GetAspxPagePath(PageName);

            //      if (string.IsNullOrEmpty(aspxPagePath))
            //      {
            //          return HttpNotFound();
            //      }
            //       string content = System.IO.File.ReadAllText(aspxPagePath);
            //       ViewBag.ASPXContent = content;
            //       return View();
            //}

          private string GetAspxPagePath(string PageName)
          {
            string FolderPath = "D:\\Omegashipping.com\\Omegashipping.com\\";

            string FullPath = Path.Combine(FolderPath, PageName);

            return FullPath;
          }
        }
}