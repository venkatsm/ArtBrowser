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

namespace ArtGallery.Controllers
{
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

                List<Image> images = new List<Image>();
                int imagesCounter = 0;

                #region Image Read
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = (HttpPostedFileBase)Request.Files[file];
                    if (hpf.ContentLength == 0)
                        continue;

                    string savedFileName = Path.Combine(Global.ImagesPath);

                    if (file == "Cover_Pic_Path")
                    {
                        savedFileName += item.Cover_Pic_Path = "\\" + "Art_Cover_Pic_" + item.User_ID + ".png";
                    }
                    else if (file.Contains("Art_Images"))
                    {
                        Image temp_Image = new Image();
                        savedFileName += temp_Image.Path = "\\" + "Art_Image_Pic_" + imagesCounter + item.User_ID + ".png";
                        imagesCounter++;

                        images.Add(temp_Image);
                    }

                    hpf.SaveAs(savedFileName.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
                }
                #endregion

                item.Location_ID = model.Location_ID;
                item.Medium = model.Medium;
                item.Price = model.Price;
                item.Size = model.Size;
                item.Statement = model.Statement;
                item.Subject = model.Subject;
                item.Title = model.Title;

                item.Status = StatusType.Draft.ToString();
                item.Created = DateTime.Now;
                item.Modified = DateTime.Now;

                db.Arts.Add(item);
                db.SaveChanges();

                if (images.Any())
                {
                    db.Images.AddRange(images.Select(x => { x.Art_ID = item.Art_ID; return x; }));
                    db.SaveChanges();
                }

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
            if (ModelState.IsValid)
            {
                item = db.Arts.Where(x => x.Art_ID == model.Art_ID).FirstOrDefault();
                TryUpdateModel(item);
                item.Modified = DateTime.Now;

                #region Image Read
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = (HttpPostedFileBase)Request.Files[file];
                    if (hpf.ContentLength == 0)
                        continue;

                    string savedFileName = Global.ImagesPath;

                    if (file == "Cover_Pic_Path")
                    {
                        savedFileName += item.Cover_Pic_Path = "Art_Cover_Pic_" + item.User_ID + ".png";
                    }
                    hpf.SaveAs(savedFileName.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
                }
                #endregion

                item.Location_ID = model.Location_ID;
                item.Medium = model.Medium;
                item.Price = model.Price;
                item.Size = model.Size;
                item.Statement = model.Statement;
                item.Subject = model.Subject;
                item.Title = model.Title;

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
                artViewModel.Cover_Pic_Path = art.Cover_Pic_Path;
                artViewModel.Art_Images = db.Images.Where(x => x.Art_ID == art.Art_ID).Select(x => x.Path).ToList();
            }
            return View(artViewModel);
        }

        // POST: Arts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
    }
}
