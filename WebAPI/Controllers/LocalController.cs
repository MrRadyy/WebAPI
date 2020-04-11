using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LocalController : ApiController
    {
        MyContext context = new MyContext();

        // GET: api/Local
        public IEnumerable<Local> Get()
        {
            return context.Local;
        }

        // GET: api/Local/5
        public Local Get(int id)
        {
            return context.Local.Find(id);
        }

        // POST: api/Local
        public void Post([FromBody]Local local)
        {
            this.context.Local.Add(local);
            this.context.SaveChanges();

        }

        // PUT: api/Local/5
        public void Put(int id, [FromBody]Local local)
        {
            Local current = this.context.Local.Find(id);

            current.Destinations_ID = local.Destinations_ID;
            current.Route = local.Route;

        }

        // DELETE: api/Local/5
        public void Delete(int id)
        {
            Local local = this.context.Local.Find(id);

            this.context.Local.Remove(local);
            this.context.SaveChanges();

        }
    }
}
