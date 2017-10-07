﻿using BookDatabase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace BookDatabase.API.Controllers
{
    [EnableCorsAttribute("http://localhost:53366","*","*")]
    public class BooksController : ApiController
    {

        // GET: api/Books
        [EnableQuery()]
        public IQueryable<Book> Get()
        {
            var bookRepository = new BookRepository();
              
            return bookRepository.Retrieve().AsQueryable(); 
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            Book book;
            var bookRepository = new BookRepository();
            if(id>0)
            {
                var books = bookRepository.Retrieve();
                book = books.FirstOrDefault(p => p.BookID == id);
            }
            else
            {
                book = bookRepository.Create();
            }
            return book;
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
