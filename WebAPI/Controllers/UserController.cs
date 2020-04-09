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

        // GET api/values
        public IEnumerable<User> Get()
        {
            return context.Users; 

        }

        // GET api/values/5
        public User Get(int id)
        {
            return context.Users.Find(id); 
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
