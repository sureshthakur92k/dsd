using dsd.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsd.Controllers
{
    public class UserDashBoardController : Controller
    {
        // GET: UserDashBoard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDashBoardIndex()
        {
            UserAssignedTask taskmodle = new UserAssignedTask();
            TaskModels taskmodle1 = new TaskModels();
            EmployeeDetailsContext _db = new EmployeeDetailsContext();
            // int fileId=_db.
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var UserGuid = user.Id;
            var adminRoleID = Guid.Parse(user.Id);
            // taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid.Equals(user.Id)).SingleOrDefault();
            taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid == adminRoleID).FirstOrDefault();

            int taskid = taskmodle.TaskId;
            taskmodle1 = _db.Task.Where(c => c.TaskId == taskid).SingleOrDefault();
            ViewBag.FileId = taskmodle1.FileId;
            return View(taskmodle);
        }
    };
}