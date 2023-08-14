using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string CommentMessage { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public Blog Blog { get; set; }
    }
}
