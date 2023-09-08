using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
