using MyWebApiProject.Models;

namespace MyWebApiProject.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly List<Author> _authors;

        public AuthorsService()
        {
            _authors = new List<Author>
            {
                new Author { Id = 1, Name = "J.K. Rowling", Biography = "Author of the Harry Potter series." },
                new Author { Id = 2, Name = "George R.R. Martin", Biography = "Author of A Song of Ice and Fire." },
                new Author { Id = 3, Name = "Isaac Asimov", Biography = "Author of the Foundation series." },
                new Author { Id = 4, Name = "Agatha Christie", Biography = "Famous for her detective novels." },
                new Author { Id = 5, Name = "Stephen King", Biography = "Master of horror and suspense." },
                new Author { Id = 6, Name = "Leo Tolstoy", Biography = "Renowned Russian author of War and Peace and Anna Karenina." },
                new Author { Id = 7, Name = "Jane Austen", Biography = "Famous for her romantic novels, including Pride and Prejudice." },
                new Author { Id = 8, Name = "Mark Twain", Biography = "Author of classic American literature like The Adventures of Tom Sawyer." },
                new Author { Id = 9, Name = "Ernest Hemingway", Biography = "Nobel Prize-winning author known for works like The Old Man and the Sea." },
                new Author { Id = 10, Name = "Mary Shelley", Biography = "Author of the Gothic novel Frankenstein." }
            };
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return Task.FromResult(_authors.AsEnumerable());
        }

        public Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(author);
        }

        public Task<Author> AddAuthorAsync(Author author)
        {
            author.Id = _authors.Max(a => a.Id) + 1;
            _authors.Add(author);
            return Task.FromResult(author);
        }

        public Task<Author> UpdateAuthorAsync(int id, Author author)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.Id == id);
            if (existingAuthor == null) return Task.FromResult<Author>(null);

            existingAuthor.Name = author.Name;
            existingAuthor.Biography = author.Biography;
            return Task.FromResult(existingAuthor);
        }

        public Task<bool> DeleteAuthorAsync(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return Task.FromResult(false);

            _authors.Remove(author);
            return Task.FromResult(true);
        }
    }
}
