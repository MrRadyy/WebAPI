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
        public string MacAddress { get; set; }
        public bool IsActive { get; set; }
        public bool Isallowed { get; set; }


    }
}