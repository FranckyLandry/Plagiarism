using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMaster.Models;
using System.Collections;
namespace PMaster.Controllers
{
    public class HomeController : Controller
    {
        private Course courseObject = new Course();
        private Teacher teacherObject = new Teacher();
        private Student studentOject = new Student();
        private ArrayList listArray = new ArrayList();
       
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //listArray.Add()


            return View();
        }
    }
}
