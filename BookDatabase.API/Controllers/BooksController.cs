using BookDatabase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookDatabase.API.Controllers
{
    [EnableCorsAttribute("http://localhost:53366","*","*")]
    public class BooksController : ApiController
    {

        // GET: api/Books
       // [EnableCorsAttribute("http://localhost:53269", "*", "*")]
        [EnableCors("http://localhost:53366", "*", "*")]
        public IEnumerable<Book> Get()
        {
            var bookRepository = new BookRepository();
               
            return bookRepository.Retrieve(); ;
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
