using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class District
    {
        [Key]

        public int DistId { get; set; }

        public string DistName { get; set; }
        public List<SubDivision> SubDivision { get;set;}
       
    }
}