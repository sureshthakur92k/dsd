using dsd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsd.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        //public ActionResult Index()
        //{
        //    using (var context = new EmployeeDetailsContext())
        //    {
        //        List<EmployeeDetails> Employeelist = context.EmployeeDetails.ToList();
        //        List<District> District1 = context.districts.ToList();
        //        List<SubDivision> SubDivision1 = context.SubDivisions.ToList();
        //    }
        //    return View();
        //}
        public ActionResult DMDashboard()
        {
            return View();
        }
        public ActionResult OtheresDashboard()
        {
            return View();
        }
    }
}