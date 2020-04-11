using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{

    [Table("FTP_Logins")]
    public class FTP_Logins
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Route { get; set; }
        public int Destinations_ID { get; set; }

    }
}