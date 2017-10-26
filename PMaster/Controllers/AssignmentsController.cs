using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMaster.Models;

namespace PMaster.Controllers
{
    public class AssignmentsController : Controller
    {
        private CanvasCloneEntities1 db = new CanvasCloneEntities1();

        // GET: Assignments
        public ActionResult Index()
        {
            var assignment = db.Assignment.Include(a => a.Course);
            return View(assignment.ToList());
        }

        // GET: Assignments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignment.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        public ActionResult AddStudent(string courseName_parameter)
        {
            if (courseName_parameter == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //Course course = db.Course.Find(courseName_parameter);
            
            Assignment assignment = db.Assignment.Find(courseName_parameter);

            //foreach (var item in assignment.Student)
            //{
            //    studentlist.Add(item);

            //}

            

            ViewBag.AssName = assignment.AssignmentName.Trim();
            ViewBag.CoursName = assignment.CourseName;
            ViewBag.Ass = assignment;
            //return View(assignment.Student);
            return View(assignment);
        }



        // GET: Assignments/Create
        //public ActionResult Create(string courseName_parameter)
        //{
        //    if (courseName_parameter == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }


        //    ViewBag.CourseName = courseName_parameter;

        //    Course course = db.Course.Find(courseName_parameter);
        //    ViewBag.Data = course.Student;

        //    return View();
        //}

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentName,CourseName")] Assignment assignment, Student st)
        {
            if (ModelState.IsValid)
            {
                db.Assignment.Add(assignment);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseName = new SelectList(db.Course, "CourseName", "CourseFilePath", assignment.CourseName);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult GetStudentList(string assignment_name)
        {
            if (assignment_name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignment.Find(assignment_name);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseName = new SelectList(db.Course, "CourseName", "CourseFilePath", assignment.CourseName);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentName,CourseName")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseName = new SelectList(db.Course, "CourseName", "CourseFilePath", assignment.CourseName);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignment.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Assignment assignment = db.Assignment.Find(id);
            db.Assignment.Remove(assignment);
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
