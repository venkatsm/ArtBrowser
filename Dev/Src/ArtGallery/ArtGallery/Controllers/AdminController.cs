using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Controllers
{
    public class AdminController : Controller
    {
        string temp_Admin = "admin";
        // GET: Admin
        public ActionResult Index(string user = "")
        {
            ViewBag.user = user;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Change_Password()
        {
            ViewBag.user = temp_Admin;
            return View();
        }



        #region Admin Views

        #region Profile
        public ActionResult UserProfile()
        {
            ViewBag.user = temp_Admin;
            return View();
        }
        #endregion


        #region Users

        public ActionResult User_Artist()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult User_Gallery()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Add_Artist()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Add_Gallery()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Artist_View()
        {
            ViewBag.user = temp_Admin;
            return View();
        }


        #endregion


        #region  Arts

        public ActionResult Arts_AddItem()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Arts_UpdateItem()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Add_Arts()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Arts_View()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        #endregion


        #region Anouncement

        public ActionResult Announcements()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Announcement_AddItem()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult Announcement_UpdateItem()
        {
            ViewBag.user = temp_Admin;
            return View();
        }


        #endregion


        #region Orders

        public ActionResult Orders()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        #endregion


        #region My Actions

        public ActionResult My_Action_User()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        public ActionResult My_Action_Arts()
        {
            ViewBag.user = temp_Admin;
            return View();
        }


        public ActionResult My_Action_Announcements()
        {
            ViewBag.user = temp_Admin;
            return View();
        }

        #endregion


        #region Search

        public ActionResult Search()
        {
            ViewBag.user = temp_Admin;
            return View();
        }



        #endregion

        #endregion


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
