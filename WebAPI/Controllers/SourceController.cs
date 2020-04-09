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

        // GET api/values
        public IEnumerable<Sources> Get()
        {
            return context.Sources;

        }

        // GET api/values/5
        public Sources Get(int id)
        {
            return context.Sources.Find(id);
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
