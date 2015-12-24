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

namespace ArtGallery.Controllers
{
    public class AnnouncementsController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Announcements
        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                var identity = ((ClaimsIdentity)User.Identity);
                string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

                announcement.Created = DateTime.Now;
                announcement.Modified = DateTime.Now; 
                                               
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Announcement_ID,Title,Description,Created,Modified")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                Announcement dbAnnouncement = db.Announcements.Find(announcement.Announcement_ID);
                TryUpdateModel(dbAnnouncement);
                dbAnnouncement.Modified = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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
