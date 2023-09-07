using CoreLayer.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        public bool IsDelivery { get; set; }
        public bool IsStock { get; set; }
        public bool IsDeactive { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public Category Category { get; set; }
    }
}
