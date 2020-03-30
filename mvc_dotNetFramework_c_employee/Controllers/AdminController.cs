using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using mvc_dotNetFramework_c_employee.Models;

namespace mvc_dotNetFramework_c_employee.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Getdata() {
            using (DBModel db = new DBModel()) {
                List<Admin> adminlist = db.Admins.ToList<Admin>();
                return Json(new { data = adminlist }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Add(Admin admin) {
            using (DBModel db = new DBModel())
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return Json(new { success = true, message = "Save Successfully" });
            }
        }
        public ActionResult Edit(Admin admin) {
            using (DBModel db = new DBModel())
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Update Successfully" });
            }
        }
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Admin admin = db.Admins.Where(a => a.adminid == id).FirstOrDefault<Admin>();
                db.Admins.Remove(admin);
                db.SaveChanges();
                return Json(new { success = true, message = "Delete Sucessfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}