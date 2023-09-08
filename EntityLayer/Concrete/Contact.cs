using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public sealed class Contact : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
