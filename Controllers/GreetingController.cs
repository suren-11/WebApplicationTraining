using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("greet")]
        public IActionResult Greet([FromQuery]string fullName, [FromQuery]DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            return Ok($"Hello, my name is {fullName} and I am {age} years old..");
        }
    }
}
