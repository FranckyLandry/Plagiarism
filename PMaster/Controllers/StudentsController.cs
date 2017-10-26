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
using System.IO.Compression;


namespace PMaster.Controllers
{
    public class StudentsController : Controller
    {
        private CanvasCloneEntities1 db = new CanvasCloneEntities1();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create(string assName_parmaters)
        {
            if (assName_parmaters == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Assignment ass = db.Assignment.Find(assName_parmaters);

            //Student student = (Student)ass.Student;

            return View(ass);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Student.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}


        [HttpPost]
        public ActionResult AddStudentFile(Assignment ass, HttpPostedFileBase fileU)
        {

            Assignment assignment = db.Assignment.Find(ass.AssignmentName);
            //assignment.AssignmentName = assignment.AssignmentName.Trim();
            
            Student student = db.Student.Find(ass.Stud.StudentID);


            if (student != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            student = new Student
            {
                FirstName = ass.Stud.FirstName,
                LastName = ass.Stud.LastName,
                StudentID = ass.Stud.StudentID,
                

            };

            Student_Assignment stud_assignment = new Student_Assignment
            {

                StudentID = student.StudentID,
                AssignmentName = assignment.AssignmentName,

            };

            Student_Course stud_course = new Student_Course
            {
                StudentID = student.StudentID,
                CourseName = assignment.CourseName
               

            };

            string basePath = HttpContext.Server.MapPath(@"\Uploads");
            string tempFile = HttpContext.Server.MapPath(@"\Temps");

            //string folderPath = Path.Combine(basePath, assignment.CourseName, assignment.AssignmentName);

            HttpPostedFileBase file = Request.Files["fileU"];
            

            string LanguageChosen = Request.Form["Projectlanguage"];



            string folder = null;
            string fullPath = null;

            UnzipFileUpload unzip = new UnzipFileUpload();

            var result = unzip.UnzipFile(file, student.StudentID, basePath, assignment, tempFile, LanguageChosen, out  folder);
            if (result == null)
            {

                student.PlagiaResultInfo = "No Plagiatism";
                if (student.PlagiaResultPercent == null)
                    student.PlagiaResultPercent = 0;

                student.CourseFilePath = folder.Trim();

                db.Student.Add(student);
                db.SaveChanges();

                db.Student_Assignment.Add(stud_assignment);
                db.SaveChanges();


                db.Student_Course.Add(stud_course);
                db.SaveChanges();

                

                return RedirectToAction("Create", new { assName_parmaters = ass.AssignmentName });

            }

           
           
            foreach (var item in result)
            {
                student.PlagiaResultInfo += item.Item1;
                if (student.PlagiaResultPercent == null)
                    student.PlagiaResultPercent = 0;
                student.PlagiaResultPercent += item.Item2;
                fullPath = item.Item3;
                
            }


            Sim sim = new Sim();
            var res = sim.FullResult(fullPath,folder);
           

            
            student.CourseFilePath = folder.Trim();
            student.PlagiaResultPercent = student.PlagiaResultPercent / result.Count();
            student.Plagia_Details = res;


            db.Student.Add(student);
            db.SaveChanges();

            db.Student_Assignment.Add(stud_assignment);
            db.SaveChanges();


            db.Student_Course.Add(stud_course);
            db.SaveChanges();


            //var result = unzip.UnzipFile(file, student.StudentID, basePath, assignment, tempFile, LanguageChosen);

            if (student.PlagiaResultInfo != null && student.PlagiaResultPercent!=null)
            { 
                ViewBag.ResultInfo = student.PlagiaResultInfo;
                ViewBag.ResultPercentage = student.PlagiaResultPercent;
                ViewBag.StudentID = student.StudentID;

            }

            //return RedirectToAction("Details", "Courses", new { nameCourse = assignment.CourseName });
            return View("Create");
        }




        public ActionResult ViewPlagiaDetails(int? stID)
        {
           
            if (stID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student st = db.Student.Find(stID);
            var path = st.Plagia_Details;
          
            Sim simRead = new Sim();
            var full_result = simRead.ReadFull_Result(path);

            //ViewBag.full_result = full_result;
            ViewBag.Plagiadet = full_result;
            ViewBag.path = path;


            return View();
        }







        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,FirstName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
