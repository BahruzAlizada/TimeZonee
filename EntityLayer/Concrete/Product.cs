using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public bool IsDelivery { get; set; }
        public bool IsStock { get; set; }
        public bool IsDeactive { get; set; }
    }
}
