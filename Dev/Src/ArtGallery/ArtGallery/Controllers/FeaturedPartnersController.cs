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

namespace ArtGallery.Controllers
{
    [Authorize]
    public class FeaturedPartnersController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: FeaturedPartners
        public ActionResult Index(int? pageNumber)
        {
            var featuredPartners = db.FeaturedPartners.Include(f => f.AspNetUser);
            return View(featuredPartners.ToList().ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        // GET: FeaturedPartners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedPartner featuredPartner = db.FeaturedPartners.Find(id);
            if (featuredPartner == null)
            {
                return HttpNotFound();
            }
            return View(featuredPartner);
        }

        // GET: FeaturedPartners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeaturedPartners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisplayInHomePage,Email")] FeaturedPartner featuredPartner)
        {
            if (ModelState.IsValid)
            {
                featuredPartner.Created = DateTime.Now;
                featuredPartner.Modified = DateTime.Now;

                var user = db.AspNetUsers.FirstOrDefault(x => x.Email.Equals(featuredPartner.Email, StringComparison.InvariantCultureIgnoreCase));
                if (user != null)
                {
                    featuredPartner.PartnerId = user.Id;
                    db.FeaturedPartners.Add(featuredPartner);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(featuredPartner);
                }
            }

            return View(featuredPartner);
        }

        // GET: FeaturedPartners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FeaturedPartner featuredPartner = db.FeaturedPartners.Find(id);
            if (featuredPartner == null)
            {
                return HttpNotFound();
            }
            
            return View(featuredPartner);
        }

        // POST: FeaturedPartners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeaturedPartnerId,Created,Modified,DisplayInHomePage,PartnerId")] FeaturedPartner featuredPartner)
        {
            if (ModelState.IsValid)
            {
                FeaturedPartner dbFeaturedPartner = db.FeaturedPartners.Find(featuredPartner.FeaturedPartnerId);
                TryUpdateModel(dbFeaturedPartner);

                dbFeaturedPartner.Modified = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(featuredPartner);
        }

        // GET: FeaturedPartners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedPartner featuredPartner = db.FeaturedPartners.Find(id);
            if (featuredPartner == null)
            {
                return HttpNotFound();
            }

            db.FeaturedPartners.Remove(featuredPartner);
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
