using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;

namespace BTK_SampleProject.Services.Interface
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(CategoryModel model);

        void DeleteCategory(Guid categoryId);
    }
}
