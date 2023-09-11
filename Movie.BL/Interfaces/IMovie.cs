namespace Movie.BL.Interfaces
{
    public interface IMovie
    {
        public Task<IEnumerable<MovieDTO>> GetAllMovies();
        public Task<MovieAndGenerDTO> GetMoviesById(int id);
        public Task<MovieDTO> UpdateMovie(int id , UpdateMovieDTO model);
        public Task<MovieDTO> DeleteMovies(int id);
        public Task<MovieDTO> CreateMovies(UpdateMovieDTO model);
    }
}
