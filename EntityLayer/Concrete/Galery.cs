using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Galery : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsDeactive { get; set; }
    }
}
