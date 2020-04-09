using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
     [Table("users")]
    public class User
    {
        public int id{ get; set; }
        public string Name{ get; set; }
        public string Suname { get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Email{ get; set; }
        


    }
}