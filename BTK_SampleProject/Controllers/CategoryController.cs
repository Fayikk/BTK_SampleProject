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
        public async Task<IActionResult> CreateCategory(CategoryModel model)
        {
            var result = await _categoryService.AddCategory(model);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest();
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

        //[HttpPut]
        //public async Task<IActionResult> UpdateCategory(Guid categoryId)
        //{
        //    var category = await _context.Categories.FindAsync(categoryId);
        //    if(category is not null)
        //    {
        //        category.CategoryName = "Phone";
        //        category.CategoryDescription = "Phones";
        //        if (await _context.SaveChangesAsync() > 0)
        //        {
        //            return Ok(category);
        //        }
        //    }
        //    return NotFound();

        //}

    }
}
