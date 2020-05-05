using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FTP_LoginsController : ApiController
    {
        MyContext context = new MyContext();

        public bool CheckTok()
        {
            return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        }



        // GET: api/FTP_Logins
        public IEnumerable<FTP_Logins> Get()
        {
            if (!CheckTok())
                return null;

            return context.FTP_Logins;
        }

        // GET: api/FTP_Logins/5
        public FTP_Logins Get(int id)
        {
            if (!CheckTok())
                return null;


            return context.FTP_Logins.Find(id);
        }

        // POST: api/FTP_Logins
        public void Post([FromBody]FTP_Logins ftplogins)
        {
            if (!CheckTok())
                return;


            this.context.FTP_Logins.Add(ftplogins);
            this.context.SaveChanges();


        }

        // PUT: api/FTP_Logins/5
        public void Put(int id, [FromBody]FTP_Logins ftplogins)
        {
            if (!CheckTok())
                return;

            FTP_Logins current = this.context.FTP_Logins.Find(id);

            current.Destinations_ID = ftplogins.Destinations_ID;
            current.Login = ftplogins.Login;
            current.Password = ftplogins.Password;
            current.Route = ftplogins.Route;
            this.context.SaveChanges();


        }

        // DELETE: api/FTP_Logins/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;

            FTP_Logins ftplogins = this.context.FTP_Logins.Find(id);

            this.context.FTP_Logins.Remove(ftplogins);
            this.context.SaveChanges();

        }
    }
}
