using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class UserAssignedTask
    {
        [Key]
        public int UserTaskId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Comment { get; set; }
        public Guid LogedInUserGuid { get; set; }


    }
}