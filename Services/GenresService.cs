using MyWebApiProject.Models;

namespace MyWebApiProject.Services
{
    public class GenresService : IGenresService
    {
        private readonly List<Genre> _genres;

        public GenresService()
        {
            _genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Non-Fiction" },
                new Genre { Id = 3, Name = "Science Fiction" },
                new Genre { Id = 4, Name = "Fantasy" },
                new Genre { Id = 5, Name = "Horror" },
                new Genre { Id = 6, Name = "Romance" },
                new Genre { Id = 7, Name = "Mystery" },
                new Genre { Id = 8, Name = "Historical" },
                new Genre { Id = 9, Name = "Thriller" },
                new Genre { Id = 10, Name = "Biography" }
            };
        }

        public Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return Task.FromResult(_genres.AsEnumerable());
        }

        public Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = _genres.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(genre);
        }

        public Task<Genre> AddGenreAsync(Genre genre)
        {
            genre.Id = _genres.Max(g => g.Id) + 1;
            _genres.Add(genre);
            return Task.FromResult(genre);
        }

        public Task<Genre> UpdateGenreAsync(int id, Genre genre)
        {
            var existingGenre = _genres.FirstOrDefault(g => g.Id == id);
            if (existingGenre == null) return Task.FromResult<Genre>(null);

            existingGenre.Name = genre.Name;
            return Task.FromResult(existingGenre);
        }

        public Task<bool> DeleteGenreAsync(int id)
        {
        var genre = _genres.FirstOrDefault(g => g.Id == id);
            if (genre == null) return Task.FromResult(false);

            _genres.Remove(genre); 
            return Task.FromResult(true); 
        }
    }
}
