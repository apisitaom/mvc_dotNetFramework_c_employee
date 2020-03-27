using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_dotNetFramework_c_employee.Models;

namespace mvc_dotNetFramework_c_employee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Getdata() {
            using (DBModel db = new DBModel()) {
                List<Employee> empList = db.Employees.ToList<Employee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (DBModel db = new DBModel())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return Json(new { success=true, message="Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}