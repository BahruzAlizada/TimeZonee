using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal=commentDal;
        }

        public void Add(Comment comment)
        {
           commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            commentDal.Delete(comment); 
        }

        public Comment GetById(int id)
        {
            return commentDal.Get(x => x.Id == id);
        }

        public List<Comment> GetCommentsByUser(string name, int pageNumber, int pageSize)
        {
            return commentDal.GetCommentsByUser(name,pageNumber,pageSize);
        }

        public int TotalCountsByUser(string name)
        {
            return commentDal.TotalCountsByUser(name);
        }

        public void Update(Comment comment)
        {
            commentDal.Update(comment); 
        }
    }
}
