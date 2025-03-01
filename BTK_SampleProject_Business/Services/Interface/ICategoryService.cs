using BTK_SampleProject.Models;
using BTK_SampleProject.Response;

namespace BTK_SampleProject.Services.Interface
{
    public interface ICategoryService
    {
        Task<BaseResponseModel> AddCategory(CategoryDTO model);
        void DeleteCategory(Guid categoryId);
        Task<BaseResponseModel> GetCategory(Guid categoryId);

        Task<BaseResponseModel> UpdateCategory(Guid categoryId,UpdateCategoryDTO categoryDTO);
    }
}
