using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    public class SourceController : ApiController
    {
        MyContext context = new MyContext();

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }

        // GET api/values
        public IEnumerable<Sources> Get()
        {
            if (!CheckTok())
                return null;


            return context.Sources;

        }

        // GET api/values/5
        public Sources Get(int id)
        {
            if (!CheckTok())
                return null;


            return context.Sources.Find(id);
        }

        // POST api/values
        public void Post([FromBody] Sources source)
        {
            if (!CheckTok())
                return;

            this.context.Sources.Add(source);
            this.context.SaveChanges(); 
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Sources sources)
        {
            if (!CheckTok())
                return;

            Sources current = this.context.Sources.Find(id);

            current.Route = sources.Route;
            current.ID_Template = sources.ID_Template;
            this.context.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;


            Sources sources = this.context.Sources.Find(id);
            this.context.Sources.Remove(sources);
            this.context.SaveChanges(); 

        }
    }
}
