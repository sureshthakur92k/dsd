using dsd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (var context = new EmployeeDetailsContext())
            //{
            //    List<EmployeeDetails> Employeelist = context.EmployeeDetails.ToList();

            //    List<District> District1 = context.districts.ToList();
            //    List<SubDivision> SubDivision1 = context.SubDivisions.ToList();
            //    return View(Employeelist);
            //}

            EmployeeDetailsContext entities = new EmployeeDetailsContext();

            DM_DashboardModel dmModel = new DM_DashboardModel();
            foreach (var district in entities.districts)
            {
                dmModel.District.Add(new SelectListItem { Text = district.DistName, Value = district.DistId.ToString() });
            }
            return View(dmModel);

            //return View();
        }

        [HttpPost]
        public ActionResult Index(int? districtId, int? subDivisionId)
        {
            DM_DashboardModel dmModel = new DM_DashboardModel();
            EmployeeDetailsContext entities = new EmployeeDetailsContext();
            foreach (var district in entities.districts)
            {
                dmModel.District.Add(new SelectListItem { Text = district.DistName, Value = district.DistId.ToString() });
            }

            if (districtId.HasValue)
            {
                var subDivisions = (from subDivision in entities.SubDivisions
                                      where subDivision.DistrictId == districtId.Value
                                      select subDivision).ToList();
                foreach (var district in subDivisions)
                {
                    dmModel.SubDivision.Add(new SelectListItem { Text = district.SubDivName, Value = district.SubDivId.ToString() });
                }

                //if (stateId.HasValue)
                //{
                //    var cities = (from city in entities.Cities
                //                  where city.StateId == stateId.Value
                //                  select city).ToList();
                //    foreach (var city in cities)
                //    {
                //        model.Cities.Add(new SelectListItem { Text = city.CityName, Value = city.CityId.ToString() });
                //    }
                //}
            }

            return View(dmModel);
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
    }
}