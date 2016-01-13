using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Data.DAL;
using ArtGallery.Models;
using System.Security.Claims;
using ArtGallery.Extensions;
using System.IO;
using ArtGallery.Common;
using ArtGallery.Helpers;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class ArtsController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Arts
        public ActionResult Index()
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            var arts = db.Arts.Where(x => x.User_ID == userid).Include(a => a.Category).Include(a => a.Location).Include(a => a.AspNetUser).OrderByDescending(a => a.Created);
            return View(arts.ToList());
        }

        // GET: Arts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Art art = db.Arts.Find(id);
            ArtsViewModel model = new ArtsViewModel();

            if (art == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.Art_ID = art.Art_ID;
                model.User_ID = art.User_ID;
                model.Category = db.Categories.Where(x => x.CategoryId == art.Category_ID).FirstOrDefault();
                model.Location = db.Locations.Where(x => x.LocationID == art.Location_ID).FirstOrDefault();
                model.Location_ID = art.Location_ID;
                model.Category_ID = art.Category_ID;
                model.Title = art.Title;
                model.Subject = art.Subject;
                model.Price = art.Price;
                model.Medium = art.Medium;
                model.Statement = art.Statement;
                model.Size = art.Size;
                model.Created = art.Created;
                model.Modified = art.Modified;
                model.Cover_Pic_Path = art.Cover_Pic_Path;
                model.Art_Images = db.Images.Where(x => x.Art_ID == art.Art_ID).Select(x => x.Path).ToList();
            }
            return View(model);
        }

        // GET: Arts/Create
        public ActionResult Create()
        {
            return View(new ArtsViewModel());
        }

        // POST: Arts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Category_ID,Subject,Price,Location_ID,Size,Medium,Statement,Status,Cover_Pic_Path,Art_Images")] ArtsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Art item = new Art();
                TryUpdateModel(item);

                var identity = ((ClaimsIdentity)User.Identity);
                string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
                item.User_ID = userid;
                item.Status = StatusType.Draft.ToString();
                item.Created = DateTime.Now;
                item.Modified = DateTime.Now;
                db.Arts.Add(item);
                db.SaveChanges();

                string imagePath = Server.MapPath(Global.ArtImages + string.Format("Art_Cover_{0}_{1}.jpg", item.Art_ID, DateTime.Now.ToString("ddMMyyss")));
                item.Cover_Pic_Path = ImageHelper.UploadImage(Request.Files["Cover_Pic_Path"], Global.ArtImages, imagePath, false);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Arts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            ArtsViewModel model = new ArtsViewModel();
            if (art == null)
            {
                return HttpNotFound();
            }
            else
            {
                model.Art_ID = art.Art_ID;
                model.User_ID = art.User_ID;
                model.Location_ID = art.Location_ID;
                model.Category_ID = art.Category_ID;
                model.Title = art.Title;
                model.Subject = art.Subject;
                model.Price = art.Price;
                model.Medium = art.Medium;
                model.Statement = art.Statement;
                model.Size = art.Size;
                model.Created = art.Created;
                model.Modified = art.Modified;
                model.Cover_Pic_Path = art.Cover_Pic_Path;
                if (model.Cover_Pic_Path == null)
                    model.Cover_Pic_Path = "~/Images/Default Images/CoverPic.png";
                model.Images = art.Images;
            }

            return View(model);
        }

        // POST: Arts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Art_ID,Title,Category_ID,Subject,Price,Location_ID,Size,Medium,Statement,Created,Modified,Status,Cover_Pic_Path,User_ID")] ArtsViewModel model)
        {
            Art item = new Art();
            string Oldcoverpicpath = "";
            if (ModelState.IsValid)
            {
                item = db.Arts.Where(x => x.Art_ID == model.Art_ID).FirstOrDefault();
                Oldcoverpicpath = item.Cover_Pic_Path;
                TryUpdateModel(item);
                item.Modified = DateTime.Now;

                if (Request.Files["Cover_Pic_Path"].ContentLength != 0)
                {
                    string imagePath = Server.MapPath(Global.ArtImages + string.Format("Art_Cover_{0}_{1}.jpg", item.Art_ID, DateTime.Now.ToString("ddMMyyss")));
                    item.Cover_Pic_Path = ImageHelper.UploadImage(Request.Files["Cover_Pic_Path"], Global.ArtImages, imagePath, false);
                }
                else
                {
                    item.Cover_Pic_Path = Oldcoverpicpath;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Arts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            ArtsViewModel artViewModel = new ArtsViewModel();
            if (art == null)
            {
                return HttpNotFound();
            }
            else
            {
                artViewModel.Art_ID = art.Art_ID;
                artViewModel.User_ID = art.User_ID;
                artViewModel.Category = db.Categories.Where(x => x.CategoryId == art.Category_ID).FirstOrDefault();
                artViewModel.Location = db.Locations.Where(x => x.LocationID == art.Location_ID).FirstOrDefault();
                artViewModel.Location_ID = art.Location_ID;
                artViewModel.Category_ID = art.Category_ID;
                artViewModel.Title = art.Title;
                artViewModel.Subject = art.Subject;
                artViewModel.Price = art.Price;
                artViewModel.Medium = art.Medium;
                artViewModel.Statement = art.Statement;
                artViewModel.Size = art.Size;
                artViewModel.Created = art.Created;
                artViewModel.Modified = art.Modified;
                artViewModel.Cover_Pic_Path = art.Cover_Pic_Path == null ? Global.DefaultCoverPic : art.Cover_Pic_Path;
                artViewModel.Art_Images = db.Images.Where(x => x.Art_ID == art.Art_ID).Select(x => x.Path).ToList();
            }
            return View(artViewModel);
        }

        // POST: Arts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Remove Images for this Art ID
            List<Image> imageColl = db.Images.Where(x => x.Art_ID == id).ToList();
            db.Images.RemoveRange(imageColl);

            // Remove Art 
            Art art = db.Arts.Find(id);
            db.Arts.Remove(art);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            string[] returnValue = new string[2];
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                HttpPostedFileBase hpf = Request.Files["ArtImage"];
                string ArtID = System.Web.HttpContext.Current.Request["ArtID"];
                if (hpf.ContentLength > 0)
                {
                    returnValue[0] = ImageHelper.UploadImage(hpf, Path.Combine(Global.ArtImages, ArtID.ToString()), string.Format("Art_Image_{0}.jpg", ArtID + DateTime.Now.ToString("G").Replace(":", "")), true);
                    Image img = new Image();
                    img.Art_ID = Convert.ToInt32(ArtID);
                    img.Path = returnValue[0];
                    db.Images.Add(img);
                    db.SaveChanges();
                    returnValue[1] = img.Image_ID.ToString();
                }
            }
            return Json(returnValue);
        }

        [HttpPost]
        public bool DeleteArtImage(int id)
        {
            bool returnValue = false;

            // Remove Art 
            Image img = db.Images.Find(id);

            if (img != null)
            {
                db.Images.Remove(img);
                db.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }
    }
}
