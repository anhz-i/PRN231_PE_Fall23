using Q1.Models;

namespace Q1
{
    public class MovieDto
    {
        public MovieDto()
        {
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int DirectorId { get; set; }
        public string? DirectorName { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
