using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dsd.Models;

namespace dsd.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        EmployeeDetailsContext _db = new EmployeeDetailsContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TaskCreation()
        {
           // ViewBag.Name = new SelectList(_db.Task.ToList(), "TaskId", "TaskName");

            return View();

        }
        [HttpPost]
        public ActionResult TaskCreation(TaskModels task)
        {
            _db.Task.Add(task);
            _db.SaveChanges();
            return View();

        }
        [HttpPost]
        public ActionResult TaskAssignment(UserAssignedTask taskAssignment)
        {
            _db.UserAssignedTask.Add(taskAssignment);
            //_db.Task.Add(task);
            _db.SaveChanges();
            return View();

        }
        public ActionResult TaskAssignment()
        {
            ViewBag.Name = new SelectList(_db.Task.ToList(), "TaskId", "TaskName");
            return View();
           // return View();

        }
        [HttpPost]
        public JsonResult GetTastDetails(int  id)
        {
            TaskModels taskmodle = new TaskModels();
            taskmodle = _db.Task.Where(c => c.TaskId == id).SingleOrDefault();
            
            return Json(taskmodle);
            //return View();
        }
        [HttpPost]
        public JsonResult GetTaskList()
        {
            List<SelectListItem> taskList = new List<SelectListItem>();
            int rowCount = _db.Task.Count();
            for (int i = 0; i < rowCount; i++)
            {
                taskList.Add(new SelectListItem
                {
                    Value = _db.Task.ToList()[i].TaskId.ToString(),
                    Text = _db.Task.ToList()[i].TaskName
                });
            }
            return Json(taskList);          
        }


        [HttpPost]
        public JsonResult GetEmployeeList()
        {
            List<SelectListItem> EmployeekList = new List<SelectListItem>();
            ApplicationDbContext _dbApplication = new ApplicationDbContext();
            int rowCount = _dbApplication.Users.Count();
            for (int i = 0; i < rowCount; i++)
            {
                EmployeekList.Add(new SelectListItem
                {
                    Value = _dbApplication.Users.ToList()[i].Id.ToString(),
                    Text = _dbApplication.Users.ToList()[i].UserName.ToString()
                });
            }
            return Json(EmployeekList);
        }

        public ActionResult fileDownload()
        {
            return View();
        }

    }
}