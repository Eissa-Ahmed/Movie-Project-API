namespace Movie.BL.Model.Gener
{
    public class GenerMovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieDTO> MovieDTO { get; set; }
    }
}
