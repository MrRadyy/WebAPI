using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{

    [Table("Computers")]
    public class Computers
    {
        public int id { get; set; }
        public string Mac_Address { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_allowed { get; set; }


    }
}