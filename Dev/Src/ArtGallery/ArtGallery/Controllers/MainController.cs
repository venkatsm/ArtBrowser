using ArtGallery.Common;
using ArtGallery.Data.DAL;
using ArtGallery.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Controllers
{
    public class MainController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        public ActionResult Events(int? pageNumber)
        {
            ViewBag.PageName = "Events";

            return View(db.Events.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        public ActionResult EventDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        public ActionResult Partners(int? pageNumber)
        {
            ViewBag.PageName = "Partners";

            return View(db.FeaturedPartners.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        public ActionResult Index()
        {
            ViewBag.PageName = "Home";
            List<Event> featuredEvents = db.Events.Where(x => x.DisplayInHomePage.HasValue && x.DisplayInHomePage.Value).ToList();
            List<FeaturedPartner> featuredPartners = db.FeaturedPartners.Where(x => x.DisplayInHomePage.HasValue && x.DisplayInHomePage.Value).ToList();

            HomeViewModel model = new HomeViewModel();
            model.Events = featuredEvents;
            model.Partners = featuredPartners;

            return View("Index_AG", model);
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

        public async Task<bool> Subscribe(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                if (!db.Subscribers.Any(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)))
                {
                    db.Subscribers.Add(new Subscriber()
                    {
                        Email = email,
                        Created = DateTime.Now,
                        IsActive = true,
                        Modified = DateTime.Now
                    });

                    db.SaveChanges();
                    string emailMessage = "Thanks for registering interest to the <a href=\"http://www.artbrowserapp.com\">ArtBrowser</a> app<br/><br/>" + Global.MailSignature;
                    // send email to admins
                    IdentityMessage message = new IdentityMessage();
                    message.Destination = email;
                    message.Subject = "Thanks for registering interest to the ArtBrowser app!";
                    message.Body = emailMessage;

                    EmailService mailService = new EmailService();
                    await mailService.SendAsync(message);
                }

                return true;
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email ID.");
                return false;
            }
        }

        public bool Unsubscribe(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                Subscriber subscriber = db.Subscribers.FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
                if (subscriber != null)
                {
                    string emailMessage = "Unsubscribed.<br/><br/>" + Global.MailSignature;
                    subscriber.IsActive = false;
                    db.SaveChanges();

                    // send email to admins
                    //IdentityMessage message = new IdentityMessage();
                    //message.Destination = email;
                    //message.Subject = "ArtBrowser Unsubscribed";
                    //message.Body = emailMessage;

                    //EmailService mailService = new EmailService();
                    //await mailService.SendAsync(message);

                    return true;
                }
            }

            return false;
        }

        public ActionResult ViewProfile(string id, string role)
        {
            UserType Role;
            Enum.TryParse<UserType>(role, out Role);
            ViewData["Role"] = Role.ToString();

            if (string.IsNullOrEmpty(id))
            {
                RedirectToAction("Index", "Main");
            }

            switch (Role)
            {
                case UserType.Artist:
                    Artist artistProfile = db.Artists.FirstOrDefault(x => x.User_ID == id);
                    artistProfile.Arts = db.Arts.Where(x => x.User_ID == id).OrderByDescending(x => x.Modified).Take(6);
                    artistProfile.LatestExhibition = db.Exhibitions.FirstOrDefault(x => x.UserId == id);
                    artistProfile.Profile_Pic = artistProfile.Profile_Pic ?? Global.DefaultProfilePic;
                    artistProfile.Cover_Pic = artistProfile.Cover_Pic ?? Global.DefaultCoverPic;

                    return View(artistProfile);
                case UserType.Institution:
                    Institution institutionProfile = db.Institutions.FirstOrDefault(x => x.User_ID == id);
                    institutionProfile.Arts = db.Arts.Where(x => x.User_ID == id).OrderByDescending(x => x.Modified).Take(6);
                    institutionProfile.LatestExhibition = db.Exhibitions.FirstOrDefault(x => x.UserId == id);
                    institutionProfile.Profile_Pic = institutionProfile.Profile_Pic ?? Global.DefaultProfilePic;
                    institutionProfile.Cover_Pic = institutionProfile.Cover_Pic ?? Global.DefaultCoverPic;

                    return View(institutionProfile);
                default:
                    RedirectToAction("Index", "Main");
                    break;
            }

            return View();
        }
    }
}