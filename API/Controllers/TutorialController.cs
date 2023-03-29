using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        // GET: api/Tutorial
        [HttpGet(Name = "GetTutorials")]
        public IEnumerable<Tutorial> Get()
        {
            return new List<Tutorial>
            {
                new Tutorial { Id = 1, Name = "Tutorial 1", Description = "Description 1", Quantity = 10 },
                new Tutorial { Id = 2, Name = "Tutorial 2", Description = "Description 2", Quantity = 20 }
            };
        }

        // GET: api/Tutorial/TutorialId/5
        [HttpGet("{id}", Name = "GetTutorial")]
        public string Get(int id)
        {
            
            
            return "value";
        }

        // POST: api/Tutorial
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
