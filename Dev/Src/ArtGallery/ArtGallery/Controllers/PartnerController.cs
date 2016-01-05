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
    public class PartnerController : Controller
    {
        ArtBrowserDBContext ArtBrowserDBContext = new ArtBrowserDBContext();
        // GET: Partner
        public ActionResult Index()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            UserType Role;
            Enum.TryParse<UserType>(User.Identity.GetClaimValue(identity.RoleClaimType), out Role);
            ViewData["Role"] = Role.ToString();

            switch (Role)
            {
                case UserType.Artist:
                    Artist artistProfile = ArtBrowserDBContext.Artists.FirstOrDefault(x => x.User_ID == userid);
                    artistProfile.Arts = ArtBrowserDBContext.Arts.Where(x => x.User_ID == userid).OrderByDescending(x => x.Modified).Take(8);
                    artistProfile.LatestExhibition = ArtBrowserDBContext.Exhibitions.FirstOrDefault(x => x.UserId == userid);
                    return View(artistProfile);
                case UserType.Institution:
                    Institution institutionProfile = ArtBrowserDBContext.Institutions.FirstOrDefault(x => x.User_ID == userid);
                    institutionProfile.Arts = ArtBrowserDBContext.Arts.Where(x => x.User_ID == userid).OrderByDescending(x => x.Modified).Take(8);
                    institutionProfile.LatestExhibition = ArtBrowserDBContext.Exhibitions.FirstOrDefault(x => x.UserId == userid);
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
                artist.Profile_Pic = ImageHelper.UploadImage(Request.Files["Profile_Pic"], Global.ProfilePics, string.Format("Profile_{0}.jpg", userid), true);
                artist.Cover_Pic = ImageHelper.UploadImage(Request.Files["Cover_Pic"], Global.ProfilePics, string.Format("Cover_{0}.jpg", userid), true);
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
                institution.Profile_Pic = ImageHelper.UploadImage(Request.Files["Profile_Pic"], Global.ProfilePics, string.Format("Profile_{0}.jpg", userid), true);
                institution.Cover_Pic = ImageHelper.UploadImage(Request.Files["Cover_Pic"], Global.ProfilePics, string.Format("Cover_{0}.jpg", userid), true);
                ArtBrowserDBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
