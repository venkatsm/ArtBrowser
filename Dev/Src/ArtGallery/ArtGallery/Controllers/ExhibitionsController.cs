using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Data.DAL;
using System.Security.Claims;
using ArtGallery.Extensions;
using PagedList;
using ArtGallery.Common;
using ArtGallery.Helpers;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class ExhibitionsController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Exhibitions
        public ActionResult Index(int? pageNumber)
        {
            var identity = ((ClaimsIdentity)User.Identity);
            string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

            var exhibitions = db.Exhibitions.Include(e => e.AspNetUser).Where(x => x.UserId == userid);
            return View(exhibitions.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        // GET: Exhibitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public ActionResult Create()
        {
            return View(new Exhibition());
        }

        // POST: Exhibitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExhibitionId,UserId,Title,ImagePath,Location,Address,Statement,StartDate,EndDate")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                TryUpdateModel(exhibition);

                var identity = ((ClaimsIdentity)User.Identity);
                string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);
                exhibition.UserId = userid;
                exhibition.Created = DateTime.Now;
                exhibition.Modified = DateTime.Now;

                string imagePath = Server.MapPath(Global.ExhibitionImages + string.Format("Exhibition_{0}_{1}.jpg", exhibition.ExhibitionId, DateTime.Now.ToString("ddMMyyss")));
                exhibition.ImagePath = ImageHelper.UploadImage(Request.Files["ImagePath"], Global.ExhibitionImages, imagePath, false);

                db.Exhibitions.Add(exhibition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }

            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExhibitionId,UserId,Title,ImagePath,Location,Address,Statement,StartDate,EndDate")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                string oldpicpath = Request.Form["OldImagePath"];
                TryUpdateModel(exhibition);
                exhibition.Modified = DateTime.Now;
                
                db.Entry(exhibition).State = EntityState.Modified;
                if (Request.Files["ImagePath"].ContentLength != 0)
                {
                    string imagePath = Server.MapPath(Global.ExhibitionImages + string.Format("Exhibition_{0}_{1}.jpg", exhibition.ExhibitionId, DateTime.Now.ToString("ddMMyyss")));
                    exhibition.ImagePath = ImageHelper.UploadImage(Request.Files["ImagePath"], Global.ExhibitionImages, imagePath, false);
                }
                else
                {
                    exhibition.ImagePath = oldpicpath;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }

            db.Exhibitions.Remove(exhibition);
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
