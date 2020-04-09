using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebAPI.Models; 
using System.Data.Entity;

namespace WebAPI.Controllers
{
    public abstract class AbstractController<T> : Controller 
    {
        protected MyContext context = new MyContext();
        protected abstract DbSet Set { get; } 

        public IEnumerable<T> Get()
        {
            return (IEnumerable<T>)Set;  
        }

     
        public T Get(T id)
        {
            return (T)Set.Find(id); 
        }

        
        public void Post([FromBody] T value)
        {
        }

       
        public void Put(T id, [FromBody] T value)
        {
        }

       
        public void Delete(T id)
        {
        }

    }
}