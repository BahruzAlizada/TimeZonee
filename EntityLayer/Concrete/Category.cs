using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public bool IsDeactive { get; set; }
    }
}
