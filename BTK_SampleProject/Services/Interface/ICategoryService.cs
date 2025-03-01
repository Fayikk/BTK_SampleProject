using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;

namespace BTK_SampleProject.Services.Interface
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(CategoryDTO model);

        void DeleteCategory(Guid categoryId);
        Task<Category> GetCategory(Guid categoryId);

        Task<Category> UpdateCategory(Guid categoryId,UpdateCategoryDTO categoryDTO);
    }
}
