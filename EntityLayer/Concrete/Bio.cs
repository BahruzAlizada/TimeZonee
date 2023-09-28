using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Bio : IEntity
    {
        public int Id { get; set; }
        public string HeaderImage { get;set; }
        public string FooterImage { get;set; }
        public string FooterDescription { get; set; }
    }
}
