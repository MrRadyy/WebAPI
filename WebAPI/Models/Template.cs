using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [Table("Template")]
    public class Template
    {
        public int id { get; set; }
        public string Template_Name { get; set; }
        public string Type_Of_Backup { get; set; }
        public string Source { get; set; }
        public string Save_Options { get; set;  }
        public string Schedule { get; set; }
    }
}