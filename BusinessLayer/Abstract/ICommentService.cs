using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetCommentsByUser(string name, int pageNumber, int pageSize);
        int TotalCountsByUser(string name);
        Comment GetById(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
