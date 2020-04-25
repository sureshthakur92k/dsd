using SK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SK2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {

            DefaultConnection con = new DefaultConnection();

            Empa dmModel = new Empa();
            foreach (var departmen in con.Emps)
            {
                dmModel.EmpName.Add(new SelectListItem { Text = departmen.Name, Value = departmen.EmpId.ToString() });
            }
            return View(dmModel);
            
            //con.Emps.ToList();
            //return View();
        }
    }
}