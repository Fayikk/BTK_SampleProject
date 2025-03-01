using AutoMapper;
using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;
using BTK_SampleProject.Services.Interface;

namespace BTK_SampleProject.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ProductDTO> CreateProduct(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            await _context.Products.AddAsync(product);
            if (await _context.SaveChangesAsync() > 0)
            {
                return dto;
            }
            return null;
        }

        public Task<List<Category>> GetProductsByCategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
