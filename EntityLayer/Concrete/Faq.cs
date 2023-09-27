using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Faq : IEntity
    {
        public int Id { get; set; }
        public string Quetsion { get; set; }
        public string Answer { get; set; }
        public bool IsDeactive { get; set; }
    }
}
