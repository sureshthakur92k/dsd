using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class TaskModels
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TaskStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TaskEndDate { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int FileId { get; set; }
        // public List<SubDivision> SubDivision { get; set; }


    }
}