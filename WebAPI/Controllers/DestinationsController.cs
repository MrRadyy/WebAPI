using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DestinationsController : ApiController
    {
        MyContext context = new MyContext();

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }



        // GET: api/Destinations
        public IEnumerable<Destinations> Get()
        {
            if (!CheckTok())
                return null;

            return context.Destinations;
        }

        // GET: api/Destinations/5
        public Destinations Get(int id)
        {
            if (!CheckTok())
                return null;

            return context.Destinations.Find(id);
        }

        // POST: api/Destinations
        public void Post([FromBody]Destinations destinations)
        {
            if (!CheckTok())
                return;

            this.context.Destinations.Add(destinations);
            this.context.SaveChanges();


        }

        // PUT: api/Destinations/5
        public void Put(int id, [FromBody]Destinations destinations)
        {
            if (!CheckTok())
                return;


            Destinations current = this.context.Destinations.Find(id);

            current.FTP = destinations.FTP;
            current.ID_Template = destinations.ID_Template;
            current.Local = destinations.Local;
            current.Network = destinations.Network;
            this.context.SaveChanges();

        }

        // DELETE: api/Destinations/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;


            Destinations destinations = this.context.Destinations.Find(id);

            this.context.Destinations.Remove(destinations);
            this.context.SaveChanges();

        }
    }
}
