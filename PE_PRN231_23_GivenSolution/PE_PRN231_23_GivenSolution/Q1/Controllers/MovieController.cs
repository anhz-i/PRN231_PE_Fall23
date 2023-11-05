using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly PE_PRN_Fall2023B1Context _context;

        public MovieController(PE_PRN_Fall2023B1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MovieResponse> GetAll()
        {
            var list = _context.Movies.Include(i => i.Genres).Include(i => i.Director)
                .Select(i => new MovieDto
                {
                    Description = i.Description,
                    Id = i.Id,
                    DirectorId = i.DirectorId,
                    DirectorName = i.Director.Name,
                    Genres = i.Genres,
                    Title = i.Title,
                    Year = i.Year,
                }).ToList();
            var list1 = new List<MovieResponse>();
            foreach (var item in list)
            {
                MovieResponse m = new MovieResponse();
                m.Title = item.Title;
                m.DirectorName = item.DirectorName;
                m.Id = item.Id;
                m.Year = item.Year;
                m.Description = item.Description;
                m.DirectorId = item.DirectorId;
                m.Genres = new List<string>();
                for (int j = 0; j < item.Genres.Count(); j++)
                {
                    m.Genres.Add(item.Genres.ElementAt(j).Title);
                }
                list1.Add(m);
            }
            return list1;
        }

        [HttpGet("GetAllMovies")]
        [EnableQuery]
        public ActionResult<List<MovieResponse>> GetAllMovies()
        {
            var list = GetAll();
            return Ok(list);
        }

        [HttpGet("GetMoviesByGenre/{genre}")]
        public ActionResult<List<MovieDto>> GetMoviesByGenre(string genre)
        {
            var list = GetAll().Where(i => i.Genres.Contains(genre)).ToList();

            return Ok(list);
        }
    }
}
