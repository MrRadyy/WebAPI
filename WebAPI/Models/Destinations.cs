using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{

    [Table("Destinations")]
    public class Destinations
    {
        public int id { get; set; }
        public string FTP { get; set; }
        public string Network { get; set; }
        public string Local { get; set; }
        public int ID_Template { get; set; }


    }
}