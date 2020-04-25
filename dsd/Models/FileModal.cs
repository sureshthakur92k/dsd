using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class FileModal
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}