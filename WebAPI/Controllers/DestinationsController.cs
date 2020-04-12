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

        // GET: api/Destinations
        public IEnumerable<Destinations> Get()
        {
            return context.Destinations;
        }

        // GET: api/Destinations/5
        public Destinations Get(int id)
        {
            return context.Destinations.Find(id);
        }

        // POST: api/Destinations
        public void Post([FromBody]Destinations destinations)
        {
            this.context.Destinations.Add(destinations);
            this.context.SaveChanges();


        }

        // PUT: api/Destinations/5
        public void Put(int id, [FromBody]Destinations destinations)
        {
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
            Destinations destinations = this.context.Destinations.Find(id);

            this.context.Destinations.Remove(destinations);
            this.context.SaveChanges();

        }
    }
}
