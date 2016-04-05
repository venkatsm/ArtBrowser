using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtGallery.Data.DAL;
using PagedList;
using ArtGallery.Common;
using System.Security.Claims;
using ArtGallery.Helpers;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Events
        public ActionResult Index(int? pageNumber)
        {
            return View(db.Events.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
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

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Title,Location,Address,Statement,StartDate,EndDate,Created,Modified,ImagePath,DisplayInHomePage,IsExternal,ExternalLink")] Event @event)
        {
            if (ModelState.IsValid)
            {
                TryUpdateModel(@event);

                @event.Created = DateTime.Now;
                @event.Modified = DateTime.Now;

                string imagePath = Server.MapPath(Global.EventImages + string.Format("Event_{0}_{1}.jpg", @event.EventId, DateTime.Now.ToString("ddMMyyss")));
                @event.ImagePath = ImageHelper.UploadImage(Request.Files["ImagePath"], Global.EventImages, imagePath, false);

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,Location,Address,Statement,StartDate,EndDate,Created,Modified,ImagePath,DisplayInHomePage,IsExternal,ExternalLink")] Event @event)
        {
            if (ModelState.IsValid)
            {
                string oldpicpath = Request.Form["OldImagePath"];
                TryUpdateModel(@event);
                @event.Modified = DateTime.Now;

                db.Entry(@event).State = EntityState.Modified;
                if (Request.Files["ImagePath"].ContentLength != 0)
                {
                    string imagePath = Server.MapPath(Global.EventImages + string.Format("Event_{0}_{1}.jpg", @event.EventId, DateTime.Now.ToString("ddMMyyss")));
                    @event.ImagePath = ImageHelper.UploadImage(Request.Files["ImagePath"], Global.EventImages, imagePath, false);
                }
                else
                {
                    @event.ImagePath = oldpicpath;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
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


            db.Events.Remove(@event);
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
