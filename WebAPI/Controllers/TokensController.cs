using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.TOKENS;

namespace WebAPI.Controllers
{
    public class TokensController : ApiController
    {
        MyContext context = new MyContext();


        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }

        // GET: api/Tokens
        public IEnumerable<Tokens> Get()
        {
            if (!CheckTok())
                return null;

            return context.Tokens;
        }

        // GET: api/Tokens/5
        public Tokens Get(int id)
        {
            if (!CheckTok())
                return null;

            return context.Tokens.Find(id);
        }

        // POST: api/Tokens
        public void Post([FromBody]Tokens token)
        {
            if (!CheckTok())
                return;

            this.context.Tokens.Add(token);
            this.context.SaveChanges();
        }

        // PUT: api/Tokens/5
        public void Put(int id, [FromBody]Tokens token)
        {
            if (!CheckTok())
                return;

            Tokens current = this.context.Tokens.Find(id);

            current.life = token.life;
            current.text = token.text;


        }

        // DELETE: api/Tokens/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;


            Tokens token = this.context.Tokens.Find(id);

            this.context.Tokens.Remove(token);
            this.context.SaveChanges();
        }

        [HttpPost]
        public string GetToken([FromBody]UsernamePassword uspas)
        {

            var temp = uspas;

            User  d =   context.Users.FirstOrDefault(item => item.Username == uspas.Username);

            if( d != null && d.Password == uspas.Password)
            {
                Tokens token = TokensGenerateVer.TK();

                this.context.Tokens.Add(token);
                this.context.SaveChanges();

                return token.text;

            }

            else
            {
                return null;

            }


        }

        [HttpDelete]
        public void DeleteToken()
        {
            string tok = Request.Headers.GetValues("tok").FirstOrDefault();
            Tokens Tok = this.context.Tokens.FirstOrDefault(item => item.text == tok);

            if(Tok != null)
            {
                Delete(Tok.ID);

            }
        }
    }
}
