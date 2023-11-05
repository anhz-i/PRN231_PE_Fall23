using Q1.Models;

namespace Q1
{
    public class MovieResponse
    {
        public MovieResponse()
        {
            Genres = new HashSet<string>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int DirectorId { get; set; }
        public string? DirectorName { get; set; }
        public virtual ICollection<string> Genres { get; set; }
    }
}
