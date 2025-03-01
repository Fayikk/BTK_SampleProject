using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;
using BTK_SampleProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTK_SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //400,404,500,200 ok

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO model)
        {
            var result = await _categoryService.AddCategory(model);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategoryById([FromQuery] Guid categoryId)
        {
            var result = await _categoryService.GetCategory(categoryId);
            if (result is not null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllCategories()
        //{
        //    List<Category> categories = await _context.Categories.ToListAsync();
        //    if(categories.Count > 0)
        //    {
        //        return Ok(categories);
        //    }
        //    return NotFound();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> RemoveCategory(Guid categoryId)
        //{
        //    var category = await _context.Categories.FindAsync(categoryId);
        //    if(category is not null)
        //    {
        //         _context.Categories.Remove(category);
        //        if (await _context.SaveChangesAsync() > 0)
        //        {
        //            return Ok("Deleted");
        //        }
        //    }

        //    return NotFound();
        //}

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid categoryId, [FromBody] UpdateCategoryDTO categoryDTO)
        {

            var result = await _categoryService.UpdateCategory(categoryId, categoryDTO);

            if (result is not null)
            {
                return Ok(result);
            }
            return NotFound();


        }
    }
}