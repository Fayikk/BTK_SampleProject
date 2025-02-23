using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTK_SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel product)
        {
            Product pObj = new Product()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                CategoryId = product.CategoryId
            };
            await _context.Products.AddAsync(pObj);
            if (await _context.SaveChangesAsync()>0)
            {
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId)
        {
            var result = await _context.Categories
                    .Include(x => x.Products)
                    .Where(x => x.Id == categoryId).ToListAsync();

            if (result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();

        }








    }
}
