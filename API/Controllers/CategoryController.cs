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
    public class CategoryController : ControllerBase
    {
        Category[] categories = new Category[]{
            new Category { Id = 1, Title = "Categoria 1", Year = 2021, Description = "Description 1"},
            new Category { Id = 2, Title = "Categoria 2", Year = 2022, Description = "Description 2" },
            new Category { Id = 3, Title = "Categoria 3", Year = 2023, Description = "Description 3"}};
        // GET: api/Category
        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> Get()
        {
            var categoriesList = categories;

            return categoriesList;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = Array.Find(categories, x => x.Id == id);

            if (category == null) { return NotFound; }

            return category;
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult Post([FromBody] Category newCategory)
        {
            if (newCategory.Id == 4) return Created("", newCategory);

            return BadRequest;
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category newCategory)
        {
            var category = Array.Find(categories, t => t.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            category = newCategory;

            return category;
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = Array.Find(categories, t => t.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return new ContentResult
            {
                ContentType = "text/plain",
                StatusCode = 200,
                Content = "Category Deleted Successfully"
            };
        }
    }
}
