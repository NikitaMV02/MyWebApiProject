using MyWebApiProject.Models;

namespace MyWebApiProject.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<Genre> AddGenreAsync(Genre genre);
        Task<Genre> UpdateGenreAsync(int id, Genre genre);
        Task<bool> DeleteGenreAsync(int id);
    }
}
