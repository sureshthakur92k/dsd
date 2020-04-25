using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class SubDivision
    {
        [Key]

        public int SubDivId { get; set; }

        public string SubDivName { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public District District { get; set; }
    }
}