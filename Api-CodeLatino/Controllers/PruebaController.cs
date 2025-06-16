using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_CodeLatino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        public PruebaController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("¡Hola, mundo!");
        }
    }
}
