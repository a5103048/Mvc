using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using slnModelValidate.Models;


namespace slnModelValidate.Controllers
{
    
    public class HomeController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();
        // GET: Home
        public ActionResult Index()
        {
            var student = db.tStudent.ToList();
            return View(student);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tStudent stu)
        {
            db.tStudent.Add(stu);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(string id)
        {
            var stu = db.tStudent
                .Where(m => m.fStuId == id).FirstOrDefault();
            db.tStudent.Remove(stu);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}