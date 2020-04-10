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
        public void Post([FromBody]Template template)
        {
            this.context.Templates.Add(template);
            this.context.SaveChanges(); 

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Template template)
        {
            Template current = this.context.Templates.Find(id);

            current.Template_Name = template.Template_Name;
            current.Type_Of_Backup = template.Type_Of_Backup;
            current.Source = template.Source;
            current.Save_Options = template.Save_Options;
            current.Schedule = template.Schedule; 


        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Template template = this.context.Templates.Find(id);
            this.context.Templates.Remove(template); 
            this.context.SaveChanges(); 

        }
    }
}
