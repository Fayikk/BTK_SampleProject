using BTK_SampleProject.Models;
using BTK_SampleProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BTK_SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            var result = await productService.CreateProduct(product);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId)
        //{
        //    var result = await _context.Categories
        //            .Include(x => x.Products)
        //            .Where(x => x.Id == categoryId).ToListAsync();

        //    if (result.Count > 0)
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound();

        //}








    }
}
