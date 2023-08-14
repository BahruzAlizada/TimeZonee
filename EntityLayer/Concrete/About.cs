using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class About : IEntity
    {
        public int Id { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
    }
}
