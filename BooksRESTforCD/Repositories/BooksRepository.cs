using BooksRESTforCD.Models;

namespace BooksRESTforCD.Repositories
{
    public class BooksRepository
    {
        private int nextId = 1;
        private readonly List<Book> books = new();

        public BooksRepository()
        {
            books.Add(new Book { Id = nextId++, Title = "Book1", Price = 100 });
            books.Add(new Book { Id = nextId++, Title = "Book2", Price = 200 });
            books.Add(new Book { Id = nextId++, Title = "Book3", Price = 300 });
        }
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>(books);
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
