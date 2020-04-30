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
            List<UserAssignedTask> taskmodleList = new List<UserAssignedTask>();
            //dynamic taskmodle = new UserAssignedTask();
            TaskModels taskmodle1 = new TaskModels();
            EmployeeDetailsContext _db = new EmployeeDetailsContext();
            // int fileId=_db.
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var UserGuid = user.Id;
            var adminRoleID = Guid.Parse(user.Id);
            // taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid.Equals(user.Id)).SingleOrDefault();
            taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid == adminRoleID).FirstOrDefault();

            int taskid = taskmodle.TaskId;
            string loggedInUserName = taskmodle.UserName;
            taskmodleList = _db.UserAssignedTask.Where(c => c.UserName == loggedInUserName).ToList();
            ViewBag.FileId = taskmodle1.FileId;
            return View(taskmodle);
        }


        public JsonResult UserDashBoardIndex1()
        {
            UserAssignedTask taskmodle = new UserAssignedTask();
            List<UserAssignedTask> taskmodleList = new List<UserAssignedTask>();
            //dynamic taskmodle = new UserAssignedTask();
            TaskModels taskmodle1 = new TaskModels();
            EmployeeDetailsContext _db = new EmployeeDetailsContext();
            // int fileId=_db.
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var UserGuid = user.Id;
            var adminRoleID = Guid.Parse(user.Id);
            // taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid.Equals(user.Id)).SingleOrDefault();
            taskmodle = _db.UserAssignedTask.Where(c => c.LogedInUserGuid == adminRoleID).FirstOrDefault();

            int taskid = taskmodle.TaskId;
            string loggedInUserName = taskmodle.UserName;
            taskmodleList = _db.UserAssignedTask.Where(c => c.UserName == loggedInUserName).ToList();
            int taskid1=0;
            int fileId1;
            foreach(var c in taskmodleList)
            {
               taskid1= c.TaskId;

                var query = from st in _db.Task
                            where st.FileId == taskid1
                            select st.FileId;

                //var student = query.SingleOrDefault<TaskModels>();
                c.FileID = query.FirstOrDefault();
              //  fileId1 = _db.Task.Where(s => s.FileId == taskid1).FirstOrDefault();

            }
            ViewBag.FileId = taskmodle1.FileId;
            return Json(taskmodleList, JsonRequestBehavior.AllowGet);
            //return View(taskmodle);
        }
        public ActionResult UserIndex()
        {
            return View();
        }
    };
}