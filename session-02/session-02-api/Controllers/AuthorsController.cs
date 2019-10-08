using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using session_02_api.Data.Extensions;
using session_02_api.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace session02api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private Context Context { get; }
        public AuthorsController(Context context)
        {
            Context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return Context.Author.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return Context.Author.ById(id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Author value)
        {
            Context.Author.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Author value)
        {
            var author = Context.Author.ById(id).FirstOrDefault();
            if(author != null)
            {
                author.Update(value);
                Context.Update(author);
                Context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = Context.Author.ById(id).FirstOrDefault();
            if(author != null)
            {
                Context.Author.Remove(author);
                Context.SaveChanges();
            }
        }
    }
}
