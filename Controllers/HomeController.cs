using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Employees.ToList();
            return View(listofData);
        }


        [HttpGet]
        public ActionResult create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult create(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Records inserted successfully";
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (data != null)
            {
                data.EmployeeName = model.EmployeeName;
                data.EmployeeSalary = model.EmployeeSalary;
                data.EmployeeDesignation = model.EmployeeDesignation;
                _context.SaveChanges();

            }
            return RedirectToAction("index");
        }



        public ActionResult Details(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            _context.SaveChanges();
            return View(data);
        }



        public ActionResult Delete(int id)
        {

            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data deleted successfully";
            return RedirectToAction("index");

        }
    }
}