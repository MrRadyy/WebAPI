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

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }


        // GET: api/Local
        public IEnumerable<Local> Get()
        {
            if (!CheckTok())
                return null;


            return context.Local;
        }

        // GET: api/Local/5
        public Local Get(int id)
        {
            if (!CheckTok())
                return null;


            return context.Local.Find(id);
        }

        // POST: api/Local
        public void Post([FromBody]Local local)
        {
            if (!CheckTok())
                return;

            this.context.Local.Add(local);
            this.context.SaveChanges();

        }

        // PUT: api/Local/5
        public void Put(int id, [FromBody]Local local)
        {
            if (!CheckTok())
                return;

            Local current = this.context.Local.Find(id);

            current.Destinations_ID = local.Destinations_ID;
            current.Route = local.Route;
            this.context.SaveChanges();
        }

        // DELETE: api/Local/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;


            Local local = this.context.Local.Find(id);

            this.context.Local.Remove(local);
            this.context.SaveChanges();

        }
    }
}
