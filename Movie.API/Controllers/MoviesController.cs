namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        #region Ctor
        private readonly IMovie movieServices;

        public MoviesController(IMovie movieServices)
        {
            this.movieServices = movieServices;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm] UpdateMovieDTO model)
        {
            try
            {
                var item = await movieServices.CreateMovies(model);
                return Ok(new ResponseModel<MovieDTO>()
                {
                    Code = 200,
                    Status = true,
                    message = "Data Is Done",
                    data = item
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<MovieDTO>()
                {
                    Code = 400,
                    Status = false,
                    message = ex.Message
                });
            }
        }
    }
}
