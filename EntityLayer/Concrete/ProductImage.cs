using CoreLayer.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
