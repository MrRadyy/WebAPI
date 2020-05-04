using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{

    [Table("Backups")]
    public class Tokens
    {
        public int ID { get; set; }
        public string text { get; set; }
        public DateTime life { get; set; }


    }
}