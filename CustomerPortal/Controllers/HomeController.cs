using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{
    [Authorize]
    [SessionValidation]
    public class HomeController : Controller
    {
        private static HomeManager home = new HomeManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Details()
        {
            try
            {
                if (Session["customerID"].ToString() !="")
                {
                    List<Customer> Details = home.GetDetails(Session["customerID"].ToString());
                    return Json(Details, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string alert = "Please Relogin";
                    FormsAuthentication.SignOut();
                    return JavaScript(alert);
                }
            }
            catch (Exception ex)
            {
                return JavaScript(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Export()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Export(string id)
        {
            if(!string.IsNullOrEmpty(id)) 
            {
            }
            return View(id);
        }
        public ActionResult Import()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ReturnExportPartialview(int Options) 
        {
            switch (Options)
            {
                case 1:
                return PartialView("~/Views/PartialView/NewBookingView.cshtml");
                case 2:
                return View();
                case 3:
                return View();
            }
            return View("ErrorPage");
        }
        public ActionResult SaveMail(int id, int Type, string Data)
        {
            try
            {
                if (home.Update(id, Type, Data))
                {
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            } 
        }
        [HttpPost]
        public ActionResult SavePhone(int id,int Type, string Data)
        {
            try
            {
                if (home.Update(id, Type, Data))
                {
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}