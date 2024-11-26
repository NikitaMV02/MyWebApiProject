using MyWebApiProject.Models;

namespace MyWebApiProject.Services
{
    public class BooksService : IBooksService
    {
        private readonly List<Book> _books;

        public BooksService()
        {
            // Імітація бази даних
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Genre = "Fantasy", Year = 1997 },
                new Book { Id = 2, Title = "A Game of Thrones", Author = "George R.R. Martin", Genre = "Fantasy", Year = 1996 },
                new Book { Id = 3, Title = "Foundation", Author = "Isaac Asimov", Genre = "Science Fiction", Year = 1951 },
                new Book { Id = 4, Title = "Murder on the Orient Express", Author = "Agatha Christie", Genre = "Mystery", Year = 1934 },
                new Book { Id = 5, Title = "The Shining", Author = "Stephen King", Genre = "Horror", Year = 1977 },
                new Book { Id = 6, Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical", Year = 1869 },
                new Book { Id = 7, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", Year = 1813 },
                new Book { Id = 8, Title = "The Adventures of Tom Sawyer", Author = "Mark Twain", Genre = "Adventure", Year = 1876 },
                new Book { Id = 9, Title = "The Old Man and the Sea", Author = "Ernest Hemingway", Genre = "Literary Fiction", Year = 1952 },
                new Book { Id = 10, Title = "Frankenstein", Author = "Mary Shelley", Genre = "Gothic Fiction", Year = 1818 },
            };
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_books.AsEnumerable());
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<Book> AddBookAsync(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return Task.FromResult(book);
        }

        public Task<Book?> UpdateBookAsync(int id, Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null) return Task.FromResult<Book?>(null);

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Year = book.Year;

            return Task.FromResult(existingBook);
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return Task.FromResult(false);

            _books.Remove(book);
            return Task.FromResult(true);
        }
    }
}
