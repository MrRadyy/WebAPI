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

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }



        // GET: api/Computers
        public IEnumerable<Computers> Get()
        {
            if (!CheckTok())
                return null;

            return context.Computers;
        }

        // GET: api/Computers/5
        public Computers Get(int id)
        {
            if (!CheckTok())
                return null;

            return context.Computers.Find(id);
        }

        // POST: api/Computers
        public int Post([FromBody]Computers computer)
        {
            if (!CheckTok())
                return -1 ;


            
            this.context.Computers.Add(computer);
            this.context.SaveChanges();
            return computer.id; 
 //           return context.Computers.ElementAt(context.Computers.Count() - 1).id ; 
        }

        public IEnumerable<Template> GetTemplates(int id)
        {
            if (!CheckTok())
                return null;

            var temp = from Computers in context.Computers
                       join Jobs in context.Jobs on Computers.id equals Jobs.ID_Computer
                       join Template in context.Templates on Jobs.ID_Template equals Template.id
                       where Computers.id == id
                       select Template;
            return temp; 

        }


        // PUT: api/Computers/5
        public void Put(int id, [FromBody]Computers computer)
        {

            if (!CheckTok())
                return;

            Computers current = this.context.Computers.Find(id);

            current.IsActive = computer.IsActive;
            current.Isallowed = computer.Isallowed;
            current.MacAddress = computer.MacAddress;

        }

        // DELETE: api/Computers/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;

            Computers computer = this.context.Computers.Find(id);

            this.context.Computers.Remove(computer);
            this.context.SaveChanges();

        }
    }
}
