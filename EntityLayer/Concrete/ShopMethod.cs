using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class ShopMethod : IEntity
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
    }
}
