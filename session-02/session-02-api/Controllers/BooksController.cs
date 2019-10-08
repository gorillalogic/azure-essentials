using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using session_02_api.Data.Extensions;
using session_02_api.Data.Model;

namespace session02api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private Context Context { get; }
        public BooksController(Context context)
        {
            Context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Context.Book.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return Context.Book.ById(id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            Context.Book.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            var book = Context.Book.ById(id).FirstOrDefault();
            if(book != null)
            {
                book.Update(value);
                Context.Book.Update(book);
                Context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = Context.Book.ById(id).FirstOrDefault();
            if(book != null)
            {
                Context.Book.Remove(book);
                Context.SaveChanges();
            }
        }
    }
}
