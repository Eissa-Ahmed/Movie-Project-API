namespace Movie.BL.Model.Movie
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
        public int Year { get; set; }
        public double Rate { get; set; }
        public int GenerId { get; set; }
    }
}
