using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Local")]
    public class Local
    {
        public int id { get; set; }
        public int Destinations_ID { get; set; }
        public string Route { get; set; }



    }
}