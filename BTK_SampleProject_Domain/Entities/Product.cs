﻿using BTK_SampleProject.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BTK_SampleProject.Entities
{//DbContext
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }//Navigation Property
    }
}
