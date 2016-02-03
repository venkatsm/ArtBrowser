using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Data.DAL;
using System.IO;
using ArtGallery.Models;
using ArtGallery.Extensions;
using ArtGallery.Common;
using ArtGallery.Helpers;

namespace ArtGallery.Controllers
{
    [Authorize]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class PartnerController : Controller
    {
        ArtBrowserDBContext ArtBrowserDBContext = new ArtBrowserDBContext();

        public PartnerController()
        {
            ViewBag.PageName = "Dashboard";
        }
        // GET: Partner
        public ActionResult Index()
        {
            ViewBag.PageName = "Dashboard";
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            UserType Role;
            Enum.TryParse<UserType>(User.Identity.GetClaimValue(identity.RoleClaimType), out Role);
            ViewData["Role"] = Role.ToString();

            switch (Role)
            {
                case UserType.Artist:
                    Artist artistProfile = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
                    artistProfile.Arts = ArtBrowserDBContext.Arts.Where(x => x.User_ID == userid).OrderByDescending(x => x.Modified).Take(6);
                    artistProfile.LatestExhibition = ArtBrowserDBContext.Exhibitions.FirstOrDefault(x => x.UserId == userid);
                    artistProfile.Profile_Pic = artistProfile.Profile_Pic ?? Global.DefaultProfilePic;
                    artistProfile.Cover_Pic = artistProfile.Cover_Pic ?? Global.DefaultCoverPic;

                    return View(artistProfile);
                case UserType.Institution:
                    Institution institutionProfile = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
                    institutionProfile.Arts = ArtBrowserDBContext.Arts.Where(x => x.User_ID == userid).OrderByDescending(x => x.Modified).Take(6);
                    institutionProfile.LatestExhibition = ArtBrowserDBContext.Exhibitions.FirstOrDefault(x => x.UserId == userid);
                    institutionProfile.Profile_Pic = institutionProfile.Profile_Pic ?? Global.DefaultProfilePic;
                    institutionProfile.Cover_Pic = institutionProfile.Cover_Pic ?? Global.DefaultCoverPic;

                    return View(institutionProfile);
                default:
                    RedirectToAction("");
                    break;
            }

            return View();
        }

        public ActionResult EditArtistProfile()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            Artist artistProfile = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
            return View(artistProfile);
        }

        public ActionResult EditInstitutionProfile()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            Institution institutionProfile = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
            return View(institutionProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtistProfile(Artist model)
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
            Artist artist = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.Artist_ID == model.Artist_ID);

            if (ModelState.IsValid && artist != null)
            {
                TryUpdateModel(artist);
                ArtBrowserDBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInstitutionProfile(Institution model)
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
            Institution institution = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.Institution_ID == model.Institution_ID);

            if (ModelState.IsValid && institution != null)
            {
                TryUpdateModel(institution);
                ArtBrowserDBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult UpdateCoverPic()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
            string returnPath = string.Empty;
           
            // get role for logged in user
            UserType Role;
            Enum.TryParse<UserType>(identity.GetClaimValue(identity.RoleClaimType), out Role);

            string imagePath = Server.MapPath(Global.ProfilePics + string.Format("Cover_{0}_{1}.jpg", userid, DateTime.Now.ToString("ddMMyyss")));
            // update cover pic background position in database
            switch (Role)
            {
                case UserType.Artist:
                    Artist artist = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
                    artist.Cover_Pic = ImageHelper.UploadImage(Request.Files["photoimg"], Global.ProfilePics, imagePath, false);
                    ArtBrowserDBContext.SaveChanges();
                    returnPath = artist.Cover_Pic;
                    break;
                case UserType.Institution:
                    Institution instution = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
                    instution.Cover_Pic = ImageHelper.UploadImage(Request.Files["photoimg"], Global.ProfilePics, imagePath, false);
                    ArtBrowserDBContext.SaveChanges();
                    returnPath = instution.Cover_Pic;
                    break;
            }
            
            return Content("<div id='uX1' class='bgSave wallbutton blackButton'>Save Cover</div><img id='timelineBGload' style='top:0px' src='" + Url.Content(returnPath) + "'  class='headerimage ui-corner-all ui-draggable' />");
        }

        [HttpPost]
        public ActionResult UpdateProfilePic()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
            
            // get role for logged in user
            UserType Role;
            Enum.TryParse<UserType>(identity.GetClaimValue(identity.RoleClaimType), out Role);

            string imagePath = Server.MapPath(Global.ProfilePics + string.Format("Profile_{0}_{1}.jpg", userid, DateTime.Now.ToString("ddMMyyss")));
            // update cover pic background position in database
            switch (Role)
            {
                case UserType.Artist:
                    Artist artist = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
                    artist.Profile_Pic = ImageHelper.UploadImage(Request.Files["profileimg"], Global.ProfilePics, imagePath, false);
                    ArtBrowserDBContext.SaveChanges();
                    break;
                case UserType.Institution:
                    Institution instution = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
                    instution.Profile_Pic = ImageHelper.UploadImage(Request.Files["profileimg"], Global.ProfilePics, imagePath, false);
                    ArtBrowserDBContext.SaveChanges();
                    break;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateCoverPicPosition(string position)
        {
            // get user identity
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            // get role for logged in user
            UserType Role;
            Enum.TryParse<UserType>(identity.GetClaimValue(identity.RoleClaimType), out Role);

            // update cover pic background position in database
            switch (Role)
            {
                case UserType.Artist:
                    Artist artist = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
                    artist.Position = string.IsNullOrEmpty(position) ? "0px" : position;
                    ArtBrowserDBContext.SaveChanges();
                    break;
                case UserType.Institution:
                    Institution instution = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
                    instution.Position = string.IsNullOrEmpty(position) ? "0px" : position;
                    ArtBrowserDBContext.SaveChanges();
                    break;
            }

            // return position
            return Content(position);
        }

        public ActionResult Followers()
        {
            ViewBag.PageName = "Dashboard";
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            UserType Role;
            Enum.TryParse<UserType>(User.Identity.GetClaimValue(identity.RoleClaimType), out Role);
            List<FollowersInfo> followers = new List<FollowersInfo>();

            return View(followers);
        }
    }
}
