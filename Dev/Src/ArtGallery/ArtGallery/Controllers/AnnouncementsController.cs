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
using ArtGallery.Models;
using PagedList;
using PagedList.Mvc;
using ArtGallery.Common;

namespace ArtGallery.Controllers
{
    public class AnnouncementsController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();
        private static string Draft = "Save as Draft";
        private static string Sumbit = "Sumbit";

        // GET: Announcements
        public ActionResult Index(int? pageNumber)
        {
            return View(db.Announcements.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
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
        public ActionResult Create([Bind(Include = "Title,Description")] Announcement announcement, string status)
        {
            if (ModelState.IsValid)
            {
                var identity = ((ClaimsIdentity)User.Identity);
                string userid = identity.GetClaimValue(ClaimTypes.NameIdentifier);

                StatusType annoucementStatus = status == Sumbit ? StatusType.PendingApproval : StatusType.Draft;
                announcement.Status = annoucementStatus.GetEnumDescription();
                announcement.User_ID = userid;
                announcement.Created = DateTime.Now;
                announcement.Modified = DateTime.Now;

                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id, string param_submit)
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
        public ActionResult Edit([Bind(Include = "Announcement_ID,Title,Description,Created,Modified")] Announcement announcement, string status)
        {
            if (ModelState.IsValid)
            {
                Announcement dbAnnouncement = db.Announcements.Find(announcement.Announcement_ID);
                TryUpdateModel(dbAnnouncement);

                StatusType annoucementStatus = status == Sumbit ? StatusType.PendingApproval : StatusType.Draft;
                dbAnnouncement.Status = annoucementStatus.GetEnumDescription();
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

        public ActionResult All()
        {
            var announcements = db.Artists;
            return View(announcements);
        }
    }
}
