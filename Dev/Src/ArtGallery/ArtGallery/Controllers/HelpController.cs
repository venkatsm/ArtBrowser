using ArtGallery.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Controllers
{
    public class HelpController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Help
        public ActionResult Index(string Type)
        {
            var configurationDetails = db.Configurations.FirstOrDefault(x => Type.Equals(x.Key, StringComparison.InvariantCultureIgnoreCase));

            if(configurationDetails != null)
            {
                return View(configurationDetails);
            }

            return RedirectToAction("Index", "Error");
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult GettingStarted()
        {
            return View();
        }
    }
}