using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerController : ControllerBase
    {
        #region Property
        private readonly IGener generServices;
        #endregion

        #region Ctor
        public GenerController(IGener generServices)
        {
            this.generServices = generServices;
        }

        #endregion

        #region Action
        [HttpGet]
        public async Task<IActionResult> GetAllGener()
        {
            try
            {
                var items = await generServices.GetAllGener();
                return Ok(new ResponseModel<IEnumerable<GenerDTO>>()
                {
                    Code = 200,
                    Status = true,
                    message = "Data Is Done",
                    data = items
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<IEnumerable<GenerDTO>>()
                {
                    Code = 400,
                    Status = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGener([FromForm] UpdateGenerDTO model)
        {
            var data = await generServices.CreateGener(model);
            if (data is null)
            {
                return BadRequest(new ResponseModel<UpdateGenerDTO>()
                {
                    Code = 400,
                    Status = false,
                    message = "Data Is Not Valid",

                });
            }
            return Ok(new ResponseModel<UpdateGenerDTO>()
            {
                Code = 200,
                Status = true,
                message = "Data Is Done",
                data = data
            });

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGener([FromRoute] int id)
        {
            var item = await generServices.DeleteGener(id);
            if (item is null)
                return BadRequest(new ResponseModel<GenerDTO>()
                {
                    Code = 400,
                    Status = false,
                    message = "Id Is Not Exist",
                });


            return Ok(new ResponseModel<GenerDTO>()
            {
                Code = 200,
                Status = true,
                message = "Data Is Done",
                data = item
            });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGener([FromRoute] int id, [FromForm] UpdateGenerDTO model)
        {
            try
            {
                var data = await generServices.UpdateGener(id, model);
                return Ok(new ResponseModel<UpdateGenerDTO>()
                {
                    Code = 200,
                    Status = true,
                    message = "Data Is Done",
                    data = data
                });
            }
            catch (Exception ex)
            {

                return Ok(new ResponseModel<UpdateGenerDTO>()
                {
                    Code = 400,
                    Status = false,
                    message = ex.Message,
                });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenerAndMovie([FromRoute] int id)
        {
            try
            {
                var data = await generServices.GetGenerAndMovieById(id);
                return Ok(new ResponseModel<GenerMovieDTO>()
                {
                    Code = 200,
                    Status = true,
                    message = "Data Is Done",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel<GenerMovieDTO>()
                {
                    Code = 400,
                    Status = false,
                    message = ex.Message
                });
            }
        }
        #endregion
    }
}
