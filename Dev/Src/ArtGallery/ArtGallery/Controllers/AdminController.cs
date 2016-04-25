using ArtGallery.Common;
using ArtGallery.Data.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult Subscribers()
        {
            var fileDownloadName = String.Format("Subscribers.xlsx");
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var datasource = db.Subscribers.Where(x => !string.IsNullOrEmpty(x.Email)).ToList();

            // Pass your ef data to method
            ExcelPackage pck = new ExcelPackage();

            //Create the worksheet 
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Subscribers");

            // Sets Headers
            ws.Cells[1, 1].Value = "Email ID";
            ws.Cells[1, 2].Value = "Is Active";
            
            // Inserts Data
            for (int i = 0; i < datasource.Count(); i++)
            {
                ws.Cells[i + 2, 1].Value = datasource.ElementAt(i).Email;
                ws.Cells[i + 2, 2].Value = datasource.ElementAt(i).IsActive;
            }

            // Format Header of Table
            using (ExcelRange rng = ws.Cells["A1:B1"])
            {

                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                rng.Style.Font.Color.SetColor(Color.Black);
            }

            var fsr = new FileContentResult(pck.GetAsByteArray(), contentType);
            fsr.FileDownloadName = fileDownloadName;

            return fsr;
        }

        public ActionResult PendingUsers(int? pageNumber)
        {
            return View(db.AspNetUsers
                .Where(x=>x.ApprovalStatus == null || x.ApprovalStatus == StatusType.PendingApproval.ToString()) 
                .OrderByDescending(x => x.Id)
                .ToList()
                .ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        public ActionResult UpdateUser(string id, string status)
        {
            var user = db.AspNetUsers.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            if(user != null)
            {
                user.ApprovalStatus = status;
                db.SaveChanges();
            }

            return RedirectToAction("PendingUsers");
        }

        public ActionResult PendingAnnouncements(int? pageNumber)
        {
            return View(db.Announcements
                .Where(x => x.Status == null || x.Status == StatusType.PendingApproval.ToString())
                .OrderByDescending(x => x.Announcement_ID)
                .ToList()
                .ToPagedList(pageNumber ?? 1, Global.PaginationSize));
        }

        public ActionResult UpdateAnnouncement(int id, string status)
        {
            var user = db.Announcements.FirstOrDefault(x => x.Announcement_ID == id);

            if (user != null)
            {
                user.Status = status;
                db.SaveChanges();
            }

            return RedirectToAction("PendingAnnouncements");
        }
    }
}
