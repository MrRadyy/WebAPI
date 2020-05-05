using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        MyContext context = new MyContext();

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }


        // GET api/values
        public IEnumerable<User> Get()
        {
            if (!CheckTok())
                return null;

            return context.Users; 

        }

        // GET api/values/5
        public User Get(int id)
        {
            if (!CheckTok())
                return null;

            return context.Users.Find(id); 
        }

        // POST api/values
        public void Post([FromBody]User user)
        {
            if (!CheckTok())
                return ;

            this.context.Users.Add(user);
            this.context.SaveChanges(); 


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]User user)
        {

            if (!CheckTok())
                return;

            User current = this.context.Users.Find(id);

            current.Name = user.Name;
            current.Suname = user.Suname;
            current.Password = user.Password;
            current.Username = user.Suname;
            current.Email = user.Email;
            current.Active = user.Active;
            this.context.SaveChanges();

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

            if (!CheckTok())
                return;


            User user = this.context.Users.Find(id);

            this.context.Users.Remove(user);
            this.context.SaveChanges(); 
            
        }

    }
}
