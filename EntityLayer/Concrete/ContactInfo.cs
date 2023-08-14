using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class ContactInfo : IEntity
    {
        public int Id { get; set; }
        public string MapIframe { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
