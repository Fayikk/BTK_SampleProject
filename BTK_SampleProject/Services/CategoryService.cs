using AutoMapper;
using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;
using BTK_SampleProject.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BTK_SampleProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 
        public CategoryService(ApplicationDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Category> AddCategory(CategoryDTO model)
        {

            #region Mapleme
            //category.CategoryName = model.CategoryName;
            //category.CategoryDescription = model.CategoryDescription;
            Category category = _mapper.Map<Category>(model);
            #endregion


            await _context.Categories.AddAsync(category);
            if (await _context.SaveChangesAsync() > 0)
            {
                return category;
            }
            return null;
        }

        public void DeleteCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategory(Guid categoryId)
        {
            Category category = await _context
                    .Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null) {
                return null;
            
            }
            return category;
        
        }

        public async Task<Category> UpdateCategory(Guid categoryId, UpdateCategoryDTO categoryDTO)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category is not null)
            {

                _mapper.Map(categoryDTO, category);
                _context.Categories.Update(category);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return category;
                }
            }
            return null;
        }
    }
}
