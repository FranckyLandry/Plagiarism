using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMaster.Models;
using System.IO;

namespace PMaster.Controllers
{
    public class CoursesController : Controller
    {
        private CanvasCloneEntities db = new CanvasCloneEntities();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Course.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseFilePath,StudentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uploadtest(HttpPostedFileBase fileUpload)
        {
            string directory = "~/Uploads/";

            HttpPostedFileBase file = Request.Files["fileUpload"];

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                
                file.SaveAs(Server.MapPath(directory + fileName));
            }

            return RedirectToAction("Index");
        }
    }
}
