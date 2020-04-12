using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ComputersController : ApiController
    {
        MyContext context = new MyContext();

        // GET: api/Computers
        public IEnumerable<Computers> Get()
        {
            return context.Computers;
        }

        // GET: api/Computers/5
        public Computers Get(int id)
        {
            return context.Computers.Find(id);
        }

        // POST: api/Computers
        public void Post([FromBody]Computers computer)
        {
            this.context.Computers.Add(computer);
            this.context.SaveChanges();

        }

        // PUT: api/Computers/5
        public void Put(int id, [FromBody]Computers computer)
        {
            Computers current = this.context.Computers.Find(id);

            current.IsActive = computer.IsActive;
            current.Isallowed = computer.Isallowed;
            current.MacAddress = computer.MacAddress;

        }

        // DELETE: api/Computers/5
        public void Delete(int id)
        {
            Computers computer = this.context.Computers.Find(id);

            this.context.Computers.Remove(computer);
            this.context.SaveChanges();

        }
    }
}
