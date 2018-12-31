using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using linq.Models;

namespace linq.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }
        public string ShowEmployee()
        {
            NorthwindEntities db = new NorthwindEntities();
            var reslut = db.員工;
            var show = "";
            foreach(var item in reslut)
            {

                show += "編號:" + item.員工編號 + "<br/>" + "姓名:" + item.姓名 + "<br/>" + "職稱" + item.職稱 + "<hr/>";
            }
            return show;

        }
    }
}