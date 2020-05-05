using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models; 
namespace WebAPI.Controllers
{
    public class NetworkController : ApiController
    {
        MyContext context = new MyContext();


        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }


        // GET api/values
        public IEnumerable<Network_Logins> Get()
        {
            if (!CheckTok())
                return null;

            return context.Networks;

        }

        // GET api/values/5
        public Network_Logins Get(int id)
        {
            if (!CheckTok())
                return null;


            return context.Networks.Find(id);
        }

        // POST api/values
        public void Post([FromBody]Network_Logins network)
        {
            this.context.Networks.Add(network);
            this.context.SaveChanges(); 

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Network_Logins network)
        {
            if (!CheckTok())
                return;


            Network_Logins current = this.context.Networks.Find(id);
            current.Network_Login = network.Network_Login;
            current.Network_Password = network.Network_Password;
            current.Network_Route = network.Network_Route;
            current.Destinations_ID = network.Destinations_ID;
            this.context.SaveChanges();


        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;

            Network_Logins logins = this.context.Networks.Find(id);
            this.context.Networks.Remove(logins);
            this.context.SaveChanges(); 




        }
    }
}
