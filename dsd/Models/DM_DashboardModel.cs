using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dsd.Models
{
    public class DM_DashboardModel
    {
        public DM_DashboardModel()
        {
            this.District = new List<SelectListItem>();
            this.SubDivision = new List<SelectListItem>();

        }

        public List<SelectListItem> District { get; set; }
        public List<SelectListItem> SubDivision { get; set; }


        public int DistrictId { get; set; }
        public int SubDivisionID { get; set; }
    }
}