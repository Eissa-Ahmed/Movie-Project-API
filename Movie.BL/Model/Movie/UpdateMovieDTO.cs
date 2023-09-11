namespace Movie.BL.Model.Movie
{
    public class UpdateMovieDTO : BaseMovieDTO
    {
        public IFormFile file { get; set; }
    }
}
