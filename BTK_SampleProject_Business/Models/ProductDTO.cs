using BTK_SampleProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTK_SampleProject.Models
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid CategoryId { get; set; }
    }
}
