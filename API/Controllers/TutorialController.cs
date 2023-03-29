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
        Tutorial[] tutorials = new Tutorial[] 
        { 
            new Tutorial { Id = 1, Name = "Tutorial 1", Description = "Description 1", Quantity = 10 },
            new Tutorial { Id = 2, Name = "Tutorial 2", Description = "Description 2", Quantity = 20 },
            new Tutorial { Id = 3, Name = "Tutorial 3", Description = "Description 3", Quantity = 30 }
        };
        
        
        // GET: api/Tutorial
        [HttpGet(Name = "GetTutorials")]
        public IEnumerable<Tutorial> Get()
        {
            
            var tutorialsList = tutorials;
            
            return tutorialsList;
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "GetTutorial")]
        public ActionResult<Tutorial> Get(int id)
        {
            var tutorial = Array.Find(tutorials, t => t.Id == id);
            
            if (tutorial == null)
            {
                return NotFound();
            }
            
            return tutorial;
        }

        // POST: api/Tutorial
        [HttpPost]
        public ActionResult Post([FromBody] Tutorial newTutorial)
        {
            // code to create a new tutorial
            
            if (newTutorial.Id==4) return Created("", newTutorial);
            
            return BadRequest();
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public ActionResult<Tutorial> Put(int id, [FromBody] Tutorial newTutorial)
        {
            var tutorial = Array.Find(tutorials, t => t.Id == id);
            
            if (tutorial == null)
            {
                return NotFound();
            }

            tutorial = newTutorial;
            
            return tutorial;
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tutorial = Array.Find(tutorials, t => t.Id == id);
            
            if (tutorial == null)
            {
                return NotFound();
            }

            return new ContentResult{
                ContentType = "text/plain",
                StatusCode = 200,
                Content = "Tutorial Deleted Successfully"
            };
        }
    }
}
