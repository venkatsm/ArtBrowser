using ArtGallery.Common;
using ArtGallery.Models;
using Microsoft.AspNet.Identity;
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

        public ActionResult Forgot_Pwd()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TermsConditions()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(Contact Model)
        {
            if(!ModelState.IsValid)
            {
                return View(Model);
            }

            // send email to admins
            IdentityMessage message = new IdentityMessage();
            message.Destination = Global.ContactMailTo;
            message.Subject = string.Format("ArtBrowser Contact - {0} - {1}", Model.Name, Model.Email);
            message.Body = string.Format("Name: {0}<br/>Email: {1}<br/>Phone Number: {2}<br/>Message: {3}", Model.Name, Model.Email, Model.PhoneNumber, Model.Message);

            EmailService mailService = new EmailService();
            mailService.SendAsync(message);
            ViewBag.Success = true;

            return View();
        }
    }
}