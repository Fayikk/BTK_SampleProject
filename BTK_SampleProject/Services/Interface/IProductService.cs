using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;

namespace BTK_SampleProject.Services.Interface
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProduct(ProductDTO dto);
        Task<List<Category>> GetProductsByCategoryId(Guid categoryId);
    }
}
