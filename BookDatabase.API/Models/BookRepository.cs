using System.Data.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace BookDatabase.API.Models
{
    public class BookRepository
    {
        private readonly BookContext _context = new BookContext();
        /// <summary>
        /// Creates a new book with default values
        /// </summary>
        /// <returns></returns>
        internal Book Create()
        {
            Book book = new Book
            {
                
            };
            return book;
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Book> Retrieve()
        {
            var books = _context.Books.Include(a => a.Author).Include(p => p.Publisher).Include(e => e.Edition).ToList();
            //var result = string.Join("", books);
            //string output = new JavaScriptSerializer().Serialize(books);
            var output = JsonConvert.SerializeObject(books);
            var jsbooks = JsonConvert.DeserializeObject<List<Book>>(output);

            return jsbooks;
        }

        /// <summary>
        /// Saves a new book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        internal Book Save(Book book)
        {
            // Read in the existing products
            var books = this.Retrieve();

            // Assign a new Id
            var maxId = books.Max(p => p.BookID);
            book.BookID = maxId + 1;
            books.Add(book);

            WriteData(books);
            return book;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        internal Book Save(int id, Book book)
        {
            // Read in the existing products
            var books = this.Retrieve();

            // Locate and replace the item
            var itemIndex = books.FindIndex(p => p.BookID == book.BookID);
            if (itemIndex > 0)
            {
                books[itemIndex] = book;
            }
            else
            {
                return null;
            }

            WriteData(books);
            return book;
        }


        private bool WriteData(List<Book> books)
        {
            // Write out the Json
            //var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");
            //Serialize collection
            var json = JsonConvert.SerializeObject(books, Formatting.Indented);
          
            foreach(var book in json)
            {
                _context.Books.AddRange(books);
            }
            _context.SaveChanges();

            return true;
        }
    }
}