using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class TokensController : ApiController
    {
        MyContext context = new MyContext();

        // GET: api/Tokens
        public IEnumerable<Tokens> Get()
        {
            return context.Tokens;
        }

        // GET: api/Tokens/5
        public Tokens Get(int id)
        {
            return context.Tokens.Find(id);
        }

        // POST: api/Tokens
        public void Post([FromBody]Tokens token)
        {
            this.context.Tokens.Add(token);
            this.context.SaveChanges();
        }

        // PUT: api/Tokens/5
        public void Put(int id, [FromBody]Tokens token)
        {
            Tokens current = this.context.Tokens.Find(id);

            current.life = token.life;
            current.text = token.text;


        }

        // DELETE: api/Tokens/5
        public void Delete(int id)
        {
            Tokens token = this.context.Tokens.Find(id);

            this.context.Tokens.Remove(token);
            this.context.SaveChanges();
        }
    }
}
