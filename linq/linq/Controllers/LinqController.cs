﻿using System;
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
        public string ShowCustomByAddress(string keyword)
        {
            NorthwindEntities db = new NorthwindEntities();
            var reslut = db.客戶.Where(m=>m.地址.Contains(keyword));
            var show = "";
            foreach (var item in reslut)
            {

                show += "公司:" + item.公司名稱 + "<br/>" + "姓名:" + item.連絡人 + "<br/>" + "地址" + item.地址 + "<hr/>";
            }
            return show;

        }
        public string Product()
        {
            NorthwindEntities db = new NorthwindEntities();
           
            string show = "";
            var result = db.產品資料
                .Where(m => m.單價 > 30)
                .OrderBy(m => m.單價)
                .ThenByDescending(m => m.庫存量);
            foreach(var item in result)
            {
                show += "產品:" + item.產品 + "<br/>" + "單價:" + item.單價+ "<br/>" + "庫存" + item.庫存量 + "<hr/>";
            }
            return show;

        }
    }
}