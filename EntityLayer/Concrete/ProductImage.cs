using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public Product Product { get; set; }
    }
}
