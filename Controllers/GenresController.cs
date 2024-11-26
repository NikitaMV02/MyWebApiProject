using Microsoft.AspNetCore.Mvc;
using MyWebApiProject.Models;
using MyWebApiProject.Services;

namespace MyWebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genresService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genresService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            var addedGenre = await _genresService.AddGenreAsync(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = addedGenre.Id }, addedGenre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] Genre genre)
        {
            var updatedGenre = await _genresService.UpdateGenreAsync(id, genre);
            if (updatedGenre == null) return NotFound();
            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _genresService.DeleteGenreAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
