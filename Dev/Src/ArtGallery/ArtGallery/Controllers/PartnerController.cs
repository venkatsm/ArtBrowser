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

namespace ArtGallery.Controllers
{
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
                    return View(artistProfile);
                case UserType.Institution:
                    Institution institutionProfile = ArtBrowserDBContext.Institutions.FirstOrDefault(x=>x.User_ID == userid);
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

            Institution institutionProfile = ArtBrowserDBContext.Institutions.FirstOrDefault(x=>x.User_ID == userid);
            return View(institutionProfile);
        }

        [HttpPost]
        public ActionResult EditArtistProfile(Artist param_Artist_Model)
        {
            if (ModelState.IsValid)
            {
                Artist Artist_Model = new Artist();
                Artist_Model = (Artist)ArtBrowserDBContext.Artists.Where(x => x.Artist_ID == param_Artist_Model.Artist_ID).FirstOrDefault();
                TryUpdateModel(Artist_Model);

                #region Image Read
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = (HttpPostedFileBase)Request.Files[file];
                    if (hpf.ContentLength == 0)
                        continue;

                    string savedFileName = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["Images_Location"]);


                    if (file == "Profile_Pic")
                        savedFileName += Artist_Model.Profile_Pic = "\\" + "Profile_" + Artist_Model.User_ID + ".png";
                    else if (file == "Cover_Pic")
                        savedFileName += Artist_Model.Cover_Pic = "\\" + "Cover_" + Artist_Model.User_ID + ".png";

                    hpf.SaveAs(savedFileName.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
                }
                #endregion

                ArtBrowserDBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(param_Artist_Model);
            }

        }

        [HttpPost]
        public ActionResult EditInstitutionProfile(Institution param_Institution_Model)
        {
            if (ModelState.IsValid)
            {
                Institution Institution_Model = new Institution();
                Institution_Model = (Institution)ArtBrowserDBContext.Institutions.Where(x => x.Institution_ID == param_Institution_Model.Institution_ID).FirstOrDefault();
                TryUpdateModel(Institution_Model);

                #region Image Read
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = (HttpPostedFileBase)Request.Files[file];
                    if (hpf.ContentLength == 0)
                        continue;

                    string savedFileName = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["Images_Location"]);

                    if (file == "Profile_Pic")
                        savedFileName += Institution_Model.Profile_Pic = "\\" + "Profile_" + Institution_Model.User_ID + ".png";
                    else if (file == "Cover_Pic")
                        savedFileName += Institution_Model.Cover_Pic = "\\" + "Cover_" + Institution_Model.User_ID + ".png";

                    hpf.SaveAs(savedFileName.Replace("~", AppDomain.CurrentDomain.BaseDirectory));


                }

                #endregion

                ArtBrowserDBContext.SaveChanges();

                return RedirectToAction("Index");
                
            }
            else
            {
                return View(param_Institution_Model);
            }
        }
    }
}
