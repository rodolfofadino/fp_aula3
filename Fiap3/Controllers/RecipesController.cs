using Fiap3.Models;
using Fiap3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap3.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RecipesController : Controller
    {
        private RecipeService _service;
        public RecipesController(RecipeService service)
        {
            _service = service;
        }

        // GET api/recipes
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return new List<Recipe> { new Recipe() { Id = 1, Title = "Bolo de chocolate" }, new Recipe() { Id = 2, Title = "Pudim" }, new Recipe() { Id = 3, Title = "Torta de frango" }, };
        }

        // GET api/recipes/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return new Recipe() { Id = id, Title = "Bolo de chocolate" };
        }

        // POST api/recipes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Recipe recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _service.SaveAsync(recipe);

            return Created($"/recipe/{recipe.Id}", recipe);
        }

        // PUT api/recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe value)
        {
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
