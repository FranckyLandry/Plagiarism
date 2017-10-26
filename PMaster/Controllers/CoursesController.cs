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
using System.Collections;

namespace PMaster.Controllers
{
    public class CoursesController : Controller
    {
        private CanvasCloneEntities1 db = new CanvasCloneEntities1();


        private Teacher teach = new Teacher();
        private Course co = new Course();
        //private Student st = new Student();
       
        
        

        // GET: Courses

        public ActionResult Index()
        {
            
           
            return View(db.Course.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(string nameCourse)
        {
            nameCourse = nameCourse.Trim();
            if (nameCourse == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(nameCourse);
           
            if (course == null)
            {
                return HttpNotFound();
            }
            course.CourseName = course.CourseName.Trim();
            foreach (var item in course.Assignment)
            {
                item.AssignmentName = item.AssignmentName.Trim();

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





        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseFilePath,StudentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Course.Find(id);
            db.Course.Remove(course);
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

//var courseList = db.Course.ToList();
//var studentList = db.Teacher.ToList();

//var container = new Tuple<Student, Teacher>(new Student(), new Teacher());


//foreach (var item in db.Course.ToList())
//{
//    if (item.CourseName == nameCourse)
//    {
//        //container./*Item2.CourseName = nameCourse;*/

//        //parts.Find(x => x.PartName.Contains("seat")))


//    }
//}
//foreach (var st in course.Student)
//{
//    foreach (var tea in course.Teacher)
//    {
//        container.Item1.FirstName = tea.FirstName;
//    }
//}
//string te = ((Student)course.Student).FirstName; 
//var container = new Tuple<Student, Teacher>(new Student(), new Teacher());
//List<Tuple<Student, Teacher>> list = new List<Tuple<Student, Teacher>>();
//var study = new Tuple<Student>(new Student());
//var teac = new Tuple<Teacher>(new Teacher());
//var studList = new List<Student>();
//var teacList = new List<Teacher>();

//            foreach (var st in course.Student)
//            {
//                container.Item1.FirstName = st.FirstName;
//                studList.Add(st);
//                 study = new Tuple<Student>(new Student { Course = st.Course, FirstName = st.FirstName, LastName = st.LastName, StudentID = st.StudentID });
//                container.Item1.Course = st.Course;
//                container.Item1.FirstName = st.FirstName;
//                container.Item1.FirstName = st.FirstName;
//            }

//            foreach (var tea in course.Teacher)
//            {
//                teacList.Add(tea);
//                teac = new Tuple<Teacher>(new Teacher { TeacherID = tea.TeacherID,LastName=tea.LastName,FirstName=tea.FirstName,Course=tea.Course});
//            }

//            //container.Item1. = new Tuple<Student, Teacher>(study, teac);
//            //list.Add(studList, teacList);