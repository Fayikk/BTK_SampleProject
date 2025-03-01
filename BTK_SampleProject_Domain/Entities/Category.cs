using BTK_SampleProject.Abstraction;

namespace BTK_SampleProject.Entities
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Product> Products { get; set; }//Navigation Property
    }
}
