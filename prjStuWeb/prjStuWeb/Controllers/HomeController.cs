using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace prjStuWeb.Controllers
{
    public class HomeController : Controller
    {
        string constr = "Data Source=.;Initial Catalog=dbStudent;Persist Security Info=True;User ID=deng;Password=123";
        // GET: Home
        public ActionResult Index()
        {
            DataTable dt = querySql("Select * from tStudent");
            return View(dt);
        }
        public void excuteSql(string sql)
        {
            SqlConnection con =new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable querySql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string fStuId,string fName,string fEmail,string fScore)
        {


            string sql = "INSERT INTO tStudent(fStuId,fName,fEmail,fScore)VALUES('"
                + fStuId.Replace("'", "''") + "',N'"
                + fName.Replace("'", "''") + "','"
                + fEmail.Replace("'", "''") + "',"
                + fScore + ")";

            excuteSql(sql);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
        {
            string sql = "DELETE FROM tStudent WHERE fStuId='"
                + id.Replace("'", "''") + "'";
            excuteSql(sql);
            DataTable dt = querySql("SELECT * FROM tStudent");
            return RedirectToAction("Index");
        }

    }
}