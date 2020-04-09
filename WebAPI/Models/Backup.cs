using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Backup

    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Size { get; set; }
        public DateTime Made { get; set; }
    }
}