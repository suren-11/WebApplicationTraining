using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Greet(string fullName, DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            return Ok($"Hello, my name is {fullName} and I am {age} years old..");
        }

        [HttpGet("findname")]
        public IActionResult getName(string name)
        {
            ArrayList fullNames = new ArrayList() { "Suren Prasanth", "Alex Pandian", "Prasanga Basnayake", "Ramesh Gunathilaka", "Alex Perera", "Suren Ram", "Prasanga Rathnayake" };
            ArrayList matchingNames = new ArrayList();

            foreach (string fullName in fullNames)
            {
                if (fullName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchingNames.Add(fullName);
                }
            }

            if (matchingNames.Count > 0)
            {
                return Ok(matchingNames);
            }

            return NotFound("No matching names found");
        }
    }
}
