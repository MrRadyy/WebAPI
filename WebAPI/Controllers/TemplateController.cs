using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    public class TemplateController : ApiController
    {
        MyContext context = new MyContext();

        // GET api/values
        public IEnumerable<Template> Get()
        {
            return context.Templates;

        }

        // GET api/values/5
        public Template Get(int id)
        {
            return context.Templates.Find(id);
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
