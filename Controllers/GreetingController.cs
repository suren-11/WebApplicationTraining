using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{fullName}/{dateOfBirth}")]
        public IActionResult Greet(string fullName, string dateOfBirth)
        {
            DateTime birthYear = DateTime.Parse(dateOfBirth);

            int age = DateTime.Now.Year - birthYear.Year;

            return Ok($"Hello, my name is {fullName} and I am {age} years old..");
        }

        [HttpGet("findname/{name}")]
        public IActionResult GetName(string name)
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

        [HttpGet("list/{names}")]
        public IActionResult GetListName(string names) 
        {
            List<string> fullNames = names.Split(',').ToList();

            return Ok($"Names Recieved {string.Join(", ",fullNames)}");

        }

    }
}
