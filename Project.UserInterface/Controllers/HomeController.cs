using Project.BusinessLayer;
using Project.BusinessLayer.Interface;
using Project.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        IEmployee _employee = null;
        public HomeController(IEmployee employee)
        {
            _employee = employee;
        }

        public ActionResult Index()
        {
            return View(_employee.GetAllData());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            _employee.Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _employee.GetSingleData(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            _employee.Edit(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _employee.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_employee.GetSingleData(id));
        }
    }
}