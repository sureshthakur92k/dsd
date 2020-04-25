using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SK2.Models
{
    public class Emp
    {
        public Emp()
        {
            this.EmpName = new List<SelectListItem>();
            //this.SubDepartmentName = new List<SelectListItem>();

        }

        public List<SelectListItem> EmpName { get; set; }
        ///public List<SelectListItem> SubDepartmentName { get; set; }


        public int EmpId { get; set; }
       // public int SubDepartmentId { get; set; }
    }
}