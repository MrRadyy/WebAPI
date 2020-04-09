using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    [Table("Network_Logins")]
    public class Network_Logins
    {
        public int id { get; set; }
        public string Network_Login { get; set; }
        public string Network_Password { get; set; }
        public string Network_Route { get; set; }
        public int Destinations_ID { get; set; }
    }
}