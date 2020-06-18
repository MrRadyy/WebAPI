using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models; 
namespace WebAPI.Controllers
{
    public class BackupController :ApiController
    {
        MyContext context = new MyContext();

        public bool CheckTok()
        {
           return context.Tokens.Select(token => token.text).Contains(this.Request.Headers.GetValues("tok").First());
        

        }


        // GET api/values
        public IEnumerable<Backup> Get()
        {
            if (!CheckTok())
                return null;


            return context.Backup;

        }
        //
        // GET api/values/5
        public Backup Get(int id)
        {
            if (!CheckTok())
                return null;
           

            return context.Backup.Find(id);
        }

        // POST api/values
        public void Post([FromBody]Backup backup)
        {
            if (!CheckTok()) 
                return;

            this.context.Backup.Add(backup);
            this.context.SaveChanges(); 



        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Backup backup)
        {
            if (!CheckTok())
                return;

            Backup current = this.context.Backup.Find(id);

            current.Name = backup.Name;
            current.Size = backup.Size;
            current.Made = backup.Made;
            current.Succesful = backup.Succesful;
            current.Job = backup.Job;
            this.context.SaveChanges();


        }


        // DELETE api/values/5
        public void Delete(int id)
        {
            if (!CheckTok())
                return;

            Backup backup = this.context.Backup.Find(id);

            this.context.Backup.Remove(backup);
            this.context.SaveChanges();
        }


    }
}