﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models; 
namespace WebAPI.Controllers
{
    public class BackupController :ApiController
    {
        MyContext context = new MyContext();

        // GET api/values
        public IEnumerable<Backup> Get()
        {
            return context.Backup;

        }

        // GET api/values/5
        public Backup Get(int id)
        {
            return context.Backup.Find(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


    }
}