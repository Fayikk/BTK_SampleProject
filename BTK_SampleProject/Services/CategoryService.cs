using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;
using BTK_SampleProject.Services.Interface;

namespace BTK_SampleProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Category> AddCategory(CategoryModel model)
        {
            Category category = new Category();
            category.CategoryName = model.CategoryName;
            category.CategoryDescription = model.CategoryDescription;
            await _context.Categories.AddAsync(category);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok(category);
            }
            return BadRequest();
        }
    }
}
