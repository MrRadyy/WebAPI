using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Jobs")]
    public class Jobs
    {

        public int id { get; set; }
        public int ID_Template { get; set; }
        public int ID_Computer { get; set; }

    }
}