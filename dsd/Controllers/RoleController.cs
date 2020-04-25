using dsd.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsd.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult RoleList()
        {
            var RoleList = db.Roles.ToList();
            return View(RoleList);

        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);

        }
        [HttpPost]
        public ActionResult CreateRole(IdentityRole identity)
        {
            db.Roles.Add(identity);
            db.SaveChanges();
            return RedirectToAction("RoleList");

        }
    }
}