using Microsoft.EntityFrameworkCore;
using Movie.BL.Helper;
using Movie.DAL.Database;
using Movie.DAL.Entity;

namespace Movie.BL.Repository
{
    public class MovieRepo : IMovie
    {
        #region Property
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        #endregion

        #region Ctor
        public MovieRepo(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        #endregion

        public async Task<MovieDTO> CreateMovies(UpdateMovieDTO model)
        {
            if (model is null)
                throw new Exception("Data Is Null");

            string? checkFile = FileManager.CheckFile(model.file);
            if (checkFile != null)
                throw new Exception(checkFile.ToString());

            var item = mapper.Map<Movies>(model);
            item.Poster = FileManager.UploadFile("Images", model.file);
            await dbContext.Movies.AddAsync(item);
            await dbContext.SaveChangesAsync();
            var item2 = await dbContext.Movies.FirstOrDefaultAsync(i => i.Poster == item.Poster);
            return mapper.Map<MovieDTO>(item2);
        }

        public async Task<MovieDTO> DeleteMovies(int id)
        {
            var item = await dbContext.Movies.FindAsync(id);
            if (item is null)
                throw new Exception("Id Not Exist");

             dbContext.Movies.Remove(item);
            await dbContext.SaveChangesAsync();
            var data = mapper.Map<MovieDTO>(item);
            return data;
        }

        public Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<MovieAndGenerDTO> GetMoviesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDTO> UpdateMovie(int id, UpdateMovieDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
