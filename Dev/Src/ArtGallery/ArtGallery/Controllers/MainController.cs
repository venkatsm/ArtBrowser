using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index(string user = "")
        {
            ViewBag.PageName = "Home";
            ViewBag.user = user;
            return View("Index_AG");
        }

        public ActionResult About()
        {
            ViewBag.PageName = "AboutUs";

            return View();
        }

        public ActionResult JoinUs()
        {
            ViewBag.PageName = "JoinUs";

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.PageName = "LogIn";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection collection)
        {
            Dictionary<string, string> Users = new Dictionary<string, string>();
            Users.Add("admin", "admin");
            Users.Add("artist", "artist");
            Users.Add("gallery", "gallery");

            string username = Convert.ToString(collection["login_username"]);
            string password = Convert.ToString(collection["login_password"]);

            if (Users.ContainsKey(username) && username == password)
            {
                //return RedirectToAction("Index", username == "admin" ? username : "partner");
                return RedirectToAction("Index", username == "admin" ? username : "partner", new { user = (username == "admin" ? username : "partner") });
            }

            return View();
        }

        public ActionResult Forgot_Pwd()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult T_and_C()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}