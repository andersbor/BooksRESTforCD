using BooksRESTforCD.Models;

namespace BooksRESTforCD.Repositories
{
    public class BooksRepository
    {
        private int nextId = 1;
        private readonly List<Book> books = new();

        public BooksRepository()
        {
            books.Add(new Book { Id = nextId++, Title = "ABC", Price = 100 });
            books.Add(new Book { Id = nextId++, Title = "C#", Price = 20 });
            books.Add(new Book { Id = nextId++, Title = "Benjamin", Price = 300 });
        }
        public IEnumerable<Book> GetAll(string? sortBy=null)
        {
            List<Book> b = new(books);
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "title":
                        b.Sort((b1, b2) => b1.Title.CompareTo(b2.Title));
                        break;
                    case "price":
                        b.Sort((b1, b2) => b1.Price.CompareTo(b2.Price));
                        break;
                    // default:
                        // do nothing
                        //throw new ArgumentException("Invalid sort_by value: " + sortBy);
                }
            }
            return b;
        }

        public Book? GetById(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public Book Add(Book book)
        {
            book.Validate();
            book.Id = nextId++;
            books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = books.Find(book => book.Id == id);
            if (book == null) return null;
            books.Remove(book);
            return book;    
        }
    }
}
